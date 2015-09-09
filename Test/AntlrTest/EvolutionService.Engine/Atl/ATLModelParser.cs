using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using EvolutionService.Engine.Core;

namespace EvolutionService.Engine.Atl
{
    public class ATLModelParser : IModelParser
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
            var lexer = new ATLLexer(new AntlrInputStream(content));
            var tokens = new CommonTokenStream(lexer);
            var parser = new ATLParser(tokens);

            if (parser.NumberOfSyntaxErrors > 0)
                return null;

            IParseTree tree = parser.unit();

            var v = new BasicAtlVisitor(context);
            v.Visit(tree);

            return v.Model;
        }
    }
}
