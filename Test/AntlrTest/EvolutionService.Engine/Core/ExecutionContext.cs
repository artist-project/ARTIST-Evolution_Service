using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core
{
    public class ExecutionContext
    {
        public Guid ExecutionId { get; set; }
        public string temp_Old { get; set; }
        public string temp_New { get; set; }
        List<object> Facts { get; set; }
        List<ChangeDefinition> DerivedChanges { get; set; }
    }
}
