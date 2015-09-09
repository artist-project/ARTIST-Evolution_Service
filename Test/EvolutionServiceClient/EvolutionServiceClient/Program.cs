using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Make sure to change API address 
                client.BaseAddress = new Uri("http://evolutionserviceapi.azurewebsites.net/");

                var oldModelFileName = @"C:\Users\bramp\Documents\Families2PersonsOld.atl";
                var newModelFileName = @"C:\Users\bramp\Documents\Families2PersonsNew.atl";

                // Add first file content 
                var fileContent1 = new ByteArrayContent(File.ReadAllBytes(oldModelFileName));
                fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Families2PersonsOld.atl",
                    ModificationDate = DateTime.Now - TimeSpan.FromMinutes(15),
                    Name = "old"
                };

                // Add Second file content 
                var fileContent2 = new ByteArrayContent(File.ReadAllBytes(newModelFileName));
                fileContent2.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Families2PersonsNew.atl",
                    ModificationDate = DateTime.Now,
                    Name = "new"
                };

                content.Add(fileContent1);
                content.Add(fileContent2);

                // Make a call to Web API 
                var result = client.PostAsync("/api/v1/upload", content).Result;
                var output = result.Content.ReadAsStringAsync();
                Console.WriteLine(result.StatusCode);
                Console.ReadLine();
            }
        }
    }
}
