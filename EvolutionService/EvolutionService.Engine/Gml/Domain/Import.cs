using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Gml.Domain
{
    public class Import : Node
    {
        public string Namespace { get; set; }
        public GoalModel Parent { get; set; }
    }
}
