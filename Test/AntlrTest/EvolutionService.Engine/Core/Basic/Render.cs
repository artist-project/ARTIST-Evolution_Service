using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core.Basic
{
    public class Render : IOperation<ExecutionContext>
    {
        public Render()
        {

        }

        public void Execute(ExecutionContext msg)
        {
            Console.WriteLine("Render");
        }
    }
}
