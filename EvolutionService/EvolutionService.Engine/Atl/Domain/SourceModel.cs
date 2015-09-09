﻿using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Atl.Domain
{
    public class SourceModel : Node
    {
        public Model Model { get; set; }
        public Module Parent { get; set; }
    }
}