using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core
{
    public class ExecutionContext
    {
        public ExecutionContext()
        {
            Facts = new List<object>();
            DerivedChanges = new List<ChangeDefinition>();
        }

        public Guid ExecutionId { get; set; }
        public List<object> Facts { get; set; }
        public List<ChangeDefinition> DerivedChanges { get; set; }
    }
}
