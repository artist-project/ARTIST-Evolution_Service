using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Configuration;
using System.Net;
using SendGrid;
using System.Net.Mail;
using EvolutionService.Engine.Core;
using EvolutionService.Engine.Core.Basic;

namespace ArtistProcessingJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("artistjobqueue")] string message, TextWriter log)
        {
            var c = new ExecutionContext() { ExecutionId = Guid.Parse(message) };

            log.WriteLine(string.Format("[{0}] Processing...", c.ExecutionId.ToString()));

            var pipeline = BasicPipeLine.Create();
            pipeline.Execute(c);

            log.WriteLine(string.Format("[{0}] {1} changes discovered.", c.ExecutionId.ToString(), c.DerivedChanges.Count()));

            NotifyMe(message);
        }

        private static void NotifyMe(string id)
        {
            var username = ConfigurationManager.AppSettings["SendGridUserName"];
            var pswd = ConfigurationManager.AppSettings["SendGridPassword"];

            var credentials = new NetworkCredential(username, pswd);

            var myMessage = new SendGridMessage();

            myMessage.From = new MailAddress("bpellens@gmail.com");
            myMessage.AddTo("bramp@spikes.be");
            myMessage.Subject = string.Format("[ArtistProcessingJob] New Job: {0}", id);
            myMessage.Text = string.Format("A new job has been submitted to the Artist Evolution Service. Guid: {0}", id);

            var transportWeb = new Web(credentials);
            transportWeb.Deliver(myMessage);
        }
    }
}
