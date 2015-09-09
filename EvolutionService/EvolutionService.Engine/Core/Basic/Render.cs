using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core.Basic
{
    public class Render : IOperation<ExecutionContext>
    {
        private EvolutionServiceContext context;

        public Render(EvolutionServiceContext context)
        {
            this.context = context;
        }

        public void Execute(ExecutionContext msg)
        {
            Unit unit = context.Units.FirstOrDefault(_ => _.UnitId == msg.ExecutionId);

            if (unit == null)
                return;

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(msg.DerivedChanges, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings() { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects });

            unit.Result = result;
            unit.Status = UnitStatus.Completed;
            unit.ModifiedDate = DateTime.UtcNow;

            context.SaveChanges();
        }
    }
}
