using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core.Basic
{
    public class Gather : IOperation<ExecutionContext>
    {
        private EvolutionServiceContext context;

        public Gather(EvolutionServiceContext context)
        {
            this.context = context;
        }

        public void Execute(ExecutionContext msg)
        {
            Unit unit = context.Units.FirstOrDefault(_ => _.UnitId == msg.ExecutionId);

            if (unit == null)
                return;

            foreach (Model m in unit.Models)
            {
                IModelParser parser = ParserFactory.Create(m.FileName);
                var model = parser.Parse(m.Data, m.Context);
                msg.Facts.AddRange(model);
            }

            unit.Status = UnitStatus.InProgress;
            unit.ModifiedDate = DateTime.UtcNow;
            context.SaveChanges();
        }
    }
}
