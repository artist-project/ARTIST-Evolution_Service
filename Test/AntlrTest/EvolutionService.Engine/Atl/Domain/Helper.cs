using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Atl.Domain
{
    public class Helper : Node
    {
        private sealed class NameEqualityComparer : IEqualityComparer<Helper>
        {
            public bool Equals(Helper x, Helper y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Helper obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Helper> NameComparerInstance = new NameEqualityComparer();

        public static IEqualityComparer<Helper> NameComparer
        {
            get { return NameComparerInstance; }
        }

        public string Name { get; set; }
        public ModelElement Context { get; set; }
        public object Parent { get; set; }
    }
}
