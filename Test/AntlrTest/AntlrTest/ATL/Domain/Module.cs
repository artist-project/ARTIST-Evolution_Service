using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTest.ATL.Domain
{
    public class Module : Node
    {
        public string Name { get; set; }
        public TransformationMode Mode { get; set; }
    }

    public enum TransformationMode
    {
        Base,
        Refactoring,
    }
}
