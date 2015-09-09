using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core.Basic
{
    public class BasicPipeLine
    {
        public static PipeLine<ExecutionContext> Create()
        {
            var pipeline = new PipeLine<ExecutionContext>();

            pipeline
                .Register(new Gather())
                .Register(new Discover())
                .Register(new Render());

            return pipeline;
        }

    }
}
