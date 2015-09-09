using EvolutionService.Engine.Atl;
using EvolutionService.Engine.Gml;
using EvolutionService.Engine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Core
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
                case ".gml":
                case ".GML":
                    return new GMLModelParser();                
                default:
                    return new TextModelParser();
            }
        }
    }
}
