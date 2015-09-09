using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolutionService.Web.Api.Infrastructure.AutoMapper
{
    public class StringToGuidConverter : TypeConverter<string, Guid>
    {
        protected override Guid ConvertCore(string source)
        {
            Guid guid;
            if (Guid.TryParse(source, out guid) == false)
                return Guid.Empty;
            return guid;
        }
    }
}