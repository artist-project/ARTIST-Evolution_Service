using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionService.Engine.Atl.Domain;

namespace EvolutionService.Engine.Atl.Definitions
{
    public class AddSourceOfModule : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class RemoveSourceOfModule : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class AddTargetOfModule : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class RemoveTargetOfModule : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class ModifySourceOfModule : ChangeDefinition
    {
        public string Name { get; set; }
        public string OldSource { get; set; }
        public string NewSource { get; set; }
    }

    public class ModifyTargetOfModule : ChangeDefinition
    {
        public string Name { get; set; }
        public string OldTarget { get; set; }
        public string NewTarget { get; set; }
    }

    public class AddRule : ChangeDefinition
    {
        public string Name { get; set; }
        public Module Parent { get; set; }
    }

    public class RemoveRule : ChangeDefinition
    {
        public string Name { get; set; }
        public Module Parent { get; set; }
    }

    //public class AddNode : ChangeDefinition
    //{
    //    public string Name { get; set; }
    //}

    //public class RemoveNode : ChangeDefinition
    //{
    //    public string Name { get; set; }
    //}

    //public class MoveConcept : ChangeDefinition
    //{
    //    public string Name { get; set; }
    //    public string OldParent { get; set; }
    //    public string NewParent { get; set; }
    //}
}
