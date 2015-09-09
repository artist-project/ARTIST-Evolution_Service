using EvolutionService.Engine.Core;
using EvolutionService.Engine.Core.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var pipeline = BasicPipeLine.Create();
            pipeline.Execute(new ExecutionContext());

            //ModelComparer comparer = new ModelComparer();
            //List<ChangeDefinition> changes = comparer.Compare(@"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\Families2PersonsOld.atl", @"C:\Repositories\artist-evolutionservice\Test\AntlrTest\AntlrTest\bin\Debug\Families2PersonsNew.atl");

            Console.ReadLine();
        }
    }
}
