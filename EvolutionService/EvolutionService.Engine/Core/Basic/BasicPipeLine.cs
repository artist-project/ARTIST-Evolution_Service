using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core.Basic
{
    public class BasicPipeLine : EvolutionManager
    {
        public static PipeLine<ExecutionContext> Create()
        {
            var pipeline = new PipeLine<ExecutionContext>();

            pipeline
                .Register(new Gather(new EvolutionServiceContext()))
                .Register(new Discover())
                .Register(new Render(new EvolutionServiceContext()));

            return pipeline;
        }

    }
}
