using System;
using System.Collections.Generic;

namespace EvolutionService.Models
{
    public partial class Model
    {
        public Model()
        {
            this.ModelId = Guid.NewGuid();
        }

        public System.Guid ModelId { get; set; }
        public System.Guid UnitId { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Context { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
