using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTest
{
    public interface IModelParser
    {
        IEnumerable<object> Parse(string f1, string f2);
    }
}
