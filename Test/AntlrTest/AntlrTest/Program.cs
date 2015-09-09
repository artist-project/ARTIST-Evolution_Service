using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrTest;
using AntlrTest.ATL.Visitors;
using AntlrTest.ChangeDetection;
using AntlrTest.Utilities;

namespace AntlrTest
{
    class Program
    {
        private static void Main(string[] args)
        {

            var oldFacts = GetValue(@"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\Families2PersonsOld.atl", "Old");
            var newFacts = GetValue(@"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\Families2PersonsNew.atl", "New");

            var facts = oldFacts.Union(newFacts).ToList();

            ModelComparer comparer = new ModelComparer();
            List<ChangeDefinition> changes = comparer.Compare(@"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\Families2PersonsOld.atl", @"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\Families2PersonsNew.atl");


            //string i = File.ReadAllText(@"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\ComponentModelGenerator.atl");



            //AntlrInputStream input = new AntlrInputStream(i);
            //ATLLexer lexer = new ATLLexer(input);
            //CommonTokenStream tokens = new CommonTokenStream(lexer);
            //ATLParser parser = new ATLParser(tokens);

            //IParseTree tree = parser.unit();

            //Console.WriteLine(tree.ToStringTree(parser));

            //ATLParser.ModuleContext c = (ATLParser.ModuleContext)tree.GetChild(0);

            //BasicAtlVisitor v = new BasicAtlVisitor(Util.VersionOld);
            //v.Visit(tree);

            //var oldModel = v.Model;

            Console.ReadLine();
        }

        private static List<object> GetValue(string fileName, string context)
        {
            IModelParser parser = ParserFactory.Create(fileName);

            return parser.Parse(fileName, context).ToList();
        }
    }
}
