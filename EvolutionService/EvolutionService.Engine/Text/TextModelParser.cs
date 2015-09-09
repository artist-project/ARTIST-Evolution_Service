using EvolutionService.Engine.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Text
{
    public class TextModelParser : IModelParser
    {
        public IEnumerable<object> Parse(string modelFileName, string context)
        {
            if (!File.Exists(modelFileName))
                return null;

            var modelContent = File.ReadAllText(modelFileName);

            return ParseModel(modelContent, context);
        }

        private IEnumerable<object> ParseModel(string content, string context)
        {
            var model = new List<object>();

            model.Add(new Content() { Body = content, Version = context });

            return model;
        }
    }
}
