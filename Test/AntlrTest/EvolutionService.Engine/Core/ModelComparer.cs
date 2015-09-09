using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core
{
    public class ModelComparer
    {
        public List<ChangeDefinition> Compare(string oldFileName, string newFileName)
        {
            var oldModel = LoadModel(oldFileName, "Old");
            var newModel = LoadModel(newFileName, "New");

            var facts = oldModel.Union(newModel).ToList();

            var processor = new FactBaseProcessor();

            return processor.Process(facts);
        }

        private static List<object> LoadModel(string fileName, string context)
        {
            IModelParser parser = ParserFactory.Create(fileName);
            return parser.Parse(fileName, context).ToList();
        }
    }
}
