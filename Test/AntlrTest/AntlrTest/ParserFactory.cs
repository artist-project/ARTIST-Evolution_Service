using AntlrTest.ATL;
using AntlrTest.RawText;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTest
{
    public class ParserFactory
    {
        public static IModelParser Create(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            switch (extension)
            {
                case ".atl":
                case ".ATL":
                    return new ATLModelParser();
                default:
                    return new RawTextModelParser();
            }
        }
    }
}
