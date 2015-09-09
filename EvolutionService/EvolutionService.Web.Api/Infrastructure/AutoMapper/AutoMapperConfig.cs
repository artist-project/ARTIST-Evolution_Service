using AutoMapper;
using EvolutionService.Models;
using EvolutionService.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolutionService.Web.Api.Infrastructure.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Guid, string>().ConvertUsing<GuidToStringConverter>();
            Mapper.CreateMap<string, Guid>().ConvertUsing<StringToGuidConverter>();

            Mapper.CreateMap<Unit, ExecutionStatusViewModel>();
        }
    }
}