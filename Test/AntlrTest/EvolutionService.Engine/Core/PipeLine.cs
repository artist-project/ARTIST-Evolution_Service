using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core
{
    public class PipeLine<T>
    {
        private readonly List<IOperation<T>> _operations = new List<IOperation<T>>();

        public PipeLine<T> Register(IOperation<T> operation)
        {
            _operations.Add(operation);
            return this;
        }

        public void Execute(T input)
        {
            _operations.ForEach(f => f.Execute(input));
        }
    }
}
