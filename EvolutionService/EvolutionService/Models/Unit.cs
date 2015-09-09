using System;
using System.Collections.Generic;

namespace EvolutionService.Models
{
    public partial class Unit
    {
        public Unit()
        {
            this.UnitId = Guid.NewGuid();
            this.Models = new List<Model>();
        }

        public System.Guid UnitId { get; set; }
        public UnitStatus Status { get; set; }
        public string Strategy { get; set; }
        public string Result { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
