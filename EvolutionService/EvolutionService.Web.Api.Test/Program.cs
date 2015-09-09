using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Web.Api.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Upload();
            Submit();

            //Demo();

            Console.ReadLine();
        }

        private static void Demo()
        {
            var id = Upload();

            Console.WriteLine("The id of the execution received: " + id);

            Console.WriteLine("Waiting...");
            System.Threading.Thread.Sleep(15000);

            Download(id);

            Console.WriteLine("Done!");
        }

        private static void Download(string id)
        {
            Console.WriteLine("Download");

            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Make sure to change API address 
                client.BaseAddress = new Uri("http://evolutionserviceapi.azurewebsites.net/");
                //client.BaseAddress = new Uri("http://localhost:52905/");

                Console.WriteLine("Downloading the result from: " + client.BaseAddress);

                var result = client.GetAsync("/api/v1/execution/" + id).Result;
                var output = result.Content.ReadAsStringAsync().Result;

                Console.WriteLine("The result is: ");
                Console.WriteLine(output);
                Console.WriteLine("---END---");
            }
        }

        public static void Submit()
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Make sure to change API address 
                client.BaseAddress = new Uri("http://evolutionserviceapi.azurewebsites.net/");
                //client.BaseAddress = new Uri("http://localhost:52905/");

                var oldModelFileName = @"C:\Repositories\artist-evolutionservice\Test\GoalModelOld.gml";
                var newModelFileName = @"C:\Repositories\artist-evolutionservice\Test\GoalModelNew.gml";

                // Add first file content 
                var fileContent1 = new ByteArrayContent(File.ReadAllBytes(oldModelFileName));
                fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "GoalModelOld.gml",
                    ModificationDate = DateTime.Now - TimeSpan.FromMinutes(15),
                    Name = "Old"
                };

                // Add Second file content 
                var fileContent2 = new ByteArrayContent(File.ReadAllBytes(newModelFileName));
                fileContent2.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "GoalModelNew.gml",
                    ModificationDate = DateTime.Now,
                    Name = "New"
                };

                content.Add(fileContent1);
                content.Add(fileContent2);

                // Make a call to Web API 
                var result = client.PostAsync("/api/v1/submit?strategy=Basic", content).Result;
                var output = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(output);
            }
        }

        public static string Upload()
        {
            Console.WriteLine("Upload");

            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Make sure to change API address 
                client.BaseAddress = new Uri("http://evolutionserviceapi.azurewebsites.net/");
                //client.BaseAddress = new Uri("http://localhost:52905/");

                var oldModelFileName = @"C:\Repositories\artist-evolutionservice\Test\Families2PersonsOld.atl";
                var newModelFileName = @"C:\Repositories\artist-evolutionservice\Test\Families2PersonsNew.atl";

                Console.WriteLine("   Old: " + oldModelFileName);
                Console.WriteLine("   New: " + newModelFileName);

                // Add first file content 
                var fileContent1 = new ByteArrayContent(File.ReadAllBytes(oldModelFileName));
                fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Families2PersonsOld.atl",
                    ModificationDate = DateTime.Now - TimeSpan.FromMinutes(15),
                    Name = "Old",
                };

                // Add Second file content 
                var fileContent2 = new ByteArrayContent(File.ReadAllBytes(newModelFileName));
                fileContent2.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Families2PersonsNew.atl",
                    ModificationDate = DateTime.Now,
                    Name = "New"
                };

                content.Add(fileContent1);
                content.Add(fileContent2);

                Console.WriteLine("Uploading the artefacts to: " + client.BaseAddress);

                // Make a call to Web API 
                var result = client.PostAsync("/api/v1/upload", content).Result;
                var output = result.Content.ReadAsStringAsync().Result;
                var converted = JsonConvert.DeserializeObject<string>(output);
                Console.WriteLine("Result: " + result.StatusCode);

                return converted;
            }
        }
    }
}
