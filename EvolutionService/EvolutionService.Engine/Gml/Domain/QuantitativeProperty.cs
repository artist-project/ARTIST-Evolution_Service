using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Gml.Domain
{
    public class QuantitativeProperty : Node
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
        public string InnerText { get; set; }
    }
}
