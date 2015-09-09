using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTest.ATL.Domain
{
    public class LibraryRef : Node
    {
        public string Name { get; set; }
        public object Parent { get; set; }
    }
}
