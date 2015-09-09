using EvolutionService.Engine.Core;
using EvolutionService.Engine.Core.Basic;
using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seed();

            //string id = "b8bdf722-bf08-44d7-bea5-8280920223d8";
            //Run(id);

            var oldModelFileName = @"C:\Repositories\artist-evolutionservice\Test\GoalModelOld.gml";
            var newModelFileName = @"C:\Repositories\artist-evolutionservice\Test\GoalModelNew.gml";
            var changes = EngineService.Process(oldModelFileName, newModelFileName);

            Console.ReadLine();
        }

        public static void Run(string id)
        {
            var c = new ExecutionContext() { ExecutionId = Guid.Parse(id) };

            Console.WriteLine("Processing " + c.ExecutionId.ToString());

            var pipeline = BasicPipeLine.Create();
            pipeline.Execute(c);

            Console.WriteLine("Changes found: " + c.DerivedChanges.Count());
            Console.WriteLine("Result: ");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(c.DerivedChanges, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings() { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All }));

            Console.ReadLine();
        }

        public static string Seed()
        {
            EvolutionServiceContext context = new EvolutionServiceContext();

            var unit = new Unit() { Status = UnitStatus.NotStarted, ModifiedDate = DateTime.UtcNow };

            var oldModelFileName = @"C:\Repositories\artist-evolutionservice\Test\Families2PersonsOld.atl";
            var newModelFileName = @"C:\Repositories\artist-evolutionservice\Test\Families2PersonsNew.atl";

            var oldModel = new Model() { FileName = oldModelFileName, Data = File.ReadAllText(oldModelFileName), Context = "Old" };
            var newModel = new Model() { FileName = newModelFileName, Data = File.ReadAllText(newModelFileName), Context = "New" };

            unit.Models.Add(oldModel);
            unit.Models.Add(newModel);

            context.Units.Add(unit);
            context.SaveChanges();

            return unit.UnitId.ToString();
        }
    }
}
