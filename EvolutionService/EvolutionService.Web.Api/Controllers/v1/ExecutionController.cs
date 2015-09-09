using AutoMapper;
using EvolutionService.Models;
using EvolutionService.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvolutionService.Web.Api.Controllers.v1
{
    [RoutePrefix("api/v1")]
    public class ExecutionController : ApiController
    {
        private EvolutionServiceContext context;

        public ExecutionController()
        {
            context = new EvolutionServiceContext();
        }

        public ExecutionController(EvolutionServiceContext context)
        {
            this.context = context;
        }

        [HttpGet, Route("execution/{id}")]
        public async Task<IHttpActionResult> GetResult(string id)
        {
            var guid = Mapper.Map<string, Guid>(id);
            var execution = await context.Units.FirstOrDefaultAsync(_ => _.UnitId == guid);

            if (execution == null)
            {
                return NotFound();
            }

            if (execution.Status == UnitStatus.Completed)
            {
                var result = new ChangeDefinitionViewModel()
                {
                    Id = Mapper.Map<Guid, string>(execution.UnitId),
                    Changes = execution.Result
                };

                return Ok(result);
            }

            return Ok();
        }

        [HttpGet, Route("execution/{id}/status")]
        public async Task<IHttpActionResult> GetStatus(string id)
        {
            var guid = Mapper.Map<string, Guid>(id);
            var execution = await context.Units.FirstOrDefaultAsync(_ => _.UnitId == guid);

            if (execution == null)
            {
                return NotFound();
            }

            var result = Mapper.Map<ExecutionStatusViewModel>(execution);
            return Ok(result);
        }
    }
}
