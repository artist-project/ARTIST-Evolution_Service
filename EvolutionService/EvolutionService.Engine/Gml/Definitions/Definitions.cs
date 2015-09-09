using EvolutionService.Engine.Gml.Domain;
using EvolutionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Gml.Definitions
{
    public class AddImport : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class RemoveImport : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class AddQualitativeProperty : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class RemoveQualitativeProperty : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class EditQualitativeProperty : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class AddQuantitativeProperty : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class RemoveQuantitativeProperty : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class EditQuantitativeProperty : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class AddHardGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class RemoveHardGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class EditHardGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class AddSoftGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class RemoveSoftGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class EditSoftGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class AddCompositeGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class RemoveCompositeGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }

    public class EditCompositeGoal : ChangeDefinition
    {
        public string Name { get; set; }
        public GoalModel Parent { get; set; }
    }
}
