using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Atl.Domain
{
    public class InModel : Node
    {
        public string Name { get; set; }
        public ModelElement Element { get; set; }
        public object Parent { get; set; }
    }
}
