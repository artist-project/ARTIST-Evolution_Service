using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolutionService.Web.Api.Infrastructure.AutoMapper
{
    public class GuidToStringConverter : TypeConverter<Guid, string>
    {
        protected override string ConvertCore(Guid source)
        {
            return source.ToString("N");
        }
    }
}