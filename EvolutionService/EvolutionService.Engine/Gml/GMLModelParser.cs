using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using EvolutionService.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Gml
{
    public class GMLModelParser : IModelParser
    {
        public IEnumerable<object> Parse(string content, string context)
        {
            var lexer = new GMLLexer(new AntlrInputStream(content));
            var tokens = new CommonTokenStream(lexer);
            var parser = new GMLParser(tokens);

            if (parser.NumberOfSyntaxErrors > 0)
                return null;

            IParseTree tree = parser.ruleGoalModel();

            var v = new BasicGmlVisitor(context);
            v.Visit(tree);

            return v.Model;
        }
    }
}
