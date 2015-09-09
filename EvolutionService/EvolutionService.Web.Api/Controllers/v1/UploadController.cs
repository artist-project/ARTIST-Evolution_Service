using AutoMapper;
using EvolutionService.Engine.Core;
using EvolutionService.Engine.Core.Basic;
using EvolutionService.Models;
using EvolutionService.Web.Api.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvolutionService.Web.Api.Controllers.v1
{
    [RoutePrefix("api/v1")]
    public class UploadController : ApiController
    {
        private EvolutionServiceContext context;

        public UploadController()
        {
            context = new EvolutionServiceContext();
        }

        public UploadController(EvolutionServiceContext context)
        {
            this.context = context;
        }

        [HttpPost, Route("submit")]
        public async Task<IHttpActionResult> SubmitArtefacts([FromUri] string strategy)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var unit = new Unit() { Status = UnitStatus.NotStarted, ModifiedDate = DateTime.UtcNow };

                unit.Strategy = (string.IsNullOrEmpty(strategy)) ? "Basic" : strategy;

                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var name = file.Headers.ContentDisposition.Name;
                    var buffer = await file.ReadAsStringAsync();
                    var model = new Model() { FileName = filename, Data = buffer, Context = name };
                    unit.Models.Add(model);
                }

                context.Units.Add(unit);
                await context.SaveChangesAsync();

                var guid = Mapper.Map<Guid, string>(unit.UnitId);

                var c = new ExecutionContext() { ExecutionId = unit.UnitId };

                var pipeline = BasicPipeLine.Create();
                pipeline.Execute(c);

                var result = Newtonsoft.Json.JsonConvert.SerializeObject(c.DerivedChanges, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings() { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects });

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [HttpPost, Route("upload")]
        public async Task<IHttpActionResult> UploadArtefacts()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var unit = new Unit() { Status = UnitStatus.NotStarted, ModifiedDate = DateTime.UtcNow };

                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var name = file.Headers.ContentDisposition.Name;
                    var buffer = await file.ReadAsStringAsync();
                    var model = new Model() { FileName = filename, Data = buffer, Context = name };
                    unit.Models.Add(model);
                }

                context.Units.Add(unit);
                await context.SaveChangesAsync();

                var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ToString());
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue messageQueue = queueClient.GetQueueReference(ConfigurationManager.AppSettings["AzureJobQueue"]);
                messageQueue.CreateIfNotExists();

                var guid = Mapper.Map<Guid, string>(unit.UnitId);

                messageQueue.AddMessage(new CloudQueueMessage(guid));

                return this.Content(HttpStatusCode.Accepted, guid);
            }
            catch (System.Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    }
}
