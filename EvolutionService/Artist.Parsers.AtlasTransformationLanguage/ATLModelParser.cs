using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artist.Parsers.AtlasTransformationLanguage
{
    public class ATLModelParser
    {
        public IParseTree Parse(string content)
        {
            var lexer = new ATLLexer(new AntlrInputStream(content));
            var tokens = new CommonTokenStream(lexer);
            var parser = new ATLParser(tokens);

            if (parser.NumberOfSyntaxErrors > 0)
                return null;

            IParseTree tree = parser.unit();

            return tree;
        }
    }
}
