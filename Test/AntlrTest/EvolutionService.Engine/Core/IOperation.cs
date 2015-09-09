using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core
{
    public interface IOperation<T>
    {
        void Execute(T msg);
    }
}
