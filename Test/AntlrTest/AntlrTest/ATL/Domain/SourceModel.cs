using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTest.ATL.Domain
{
    public class SourceModel : Node
    {
        public Model Model { get; set; }
        public Module Parent { get; set; }
    }
}
