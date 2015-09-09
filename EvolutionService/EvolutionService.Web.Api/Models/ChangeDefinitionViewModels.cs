using EvolutionService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolutionService.Web.Api.Models
{
    public class ChangeDefinitionViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("changes")]
        public string Changes { get; set; }
    }

    public class ExecutionStatusViewModel
    {
        [JsonProperty("id")]
        public string UnitId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}