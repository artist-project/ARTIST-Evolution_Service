using EvolutionService.Engine.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Test
{
    public class EngineService
    {
        public static List<Models.ChangeDefinition> Process(string oldArtefactFileName, string newArtefactFileName)
        {
            var facts = new List<object>();

            var oldModel = Load(oldArtefactFileName, "Old");
            facts.AddRange(oldModel);

            var newModel = Load(newArtefactFileName, "New");
            facts.AddRange(newModel);

            var processor = new FactBaseProcessor();

            var derivedChanges = processor.Process(facts);

            return derivedChanges;
        }

        private static IEnumerable<object> Load(string fileName, string context)
        {
            var content = File.ReadAllText(fileName);

            IModelParser parser = ParserFactory.Create(fileName);

            var model = parser.Parse(content, context);

            return model;
        }


    }
}
