using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTest.ATL.Domain
{
    public class Rule : Node
    {
        private sealed class NameEqualityComparer : IEqualityComparer<Rule>
        {
            public bool Equals(Rule x, Rule y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Rule obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Rule> NameComparerInstance = new NameEqualityComparer();

        public static IEqualityComparer<Rule> NameComparer
        {
            get { return NameComparerInstance; }
        }

        public string Name { get; set; }
        public bool Lazy { get; set; }
        public Module Parent { get; set; }
    }
}
