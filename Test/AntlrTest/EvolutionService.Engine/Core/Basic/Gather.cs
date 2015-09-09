using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core.Basic
{
    public class Gather : IOperation<ExecutionContext>
    {
        public Gather()
        {

        }

        public void Execute(ExecutionContext msg)
        {
            Console.WriteLine("Gather");
        }
    }
}
