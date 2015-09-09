using EvolutionService.Engine.Gml.Definitions;
using EvolutionService.Engine.Gml.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Gml.Rules
{
    public class AddImportRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Import newNode = null;

            When()
                .Match<Import>(() => newNode, _ => _.Version == "New")
                .Not<Import>(n => n.Version == "Old",
                    n => n.Namespace == newNode.Namespace,
                    n => n.Parent.Name == newNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddImport()
            {
                Name = newNode.Namespace,
                Parent = newNode.Parent
            }));
        }
    }

    public class RemoveImportRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Import oldNode = null;

            When()
                .Match<Import>(() => oldNode, _ => _.Version == "Old")
                .Not<Import>(n => n.Version == "New",
                    n => n.Namespace == oldNode.Namespace,
                    n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveImport()
            {
                Name = oldNode.Namespace,
                Parent = oldNode.Parent
            }));
        }
    }

    public class AddQualitativePropertyRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            QualitativeProperty newNode = null;

            When()
                .Match<QualitativeProperty>(() => newNode, _ => _.Version == "New")
                .Not<QualitativeProperty>(n => n.Version == "Old",
                    n => n.Name == newNode.Name,
                    n => n.Parent.Name == newNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddQualitativeProperty()
            {
                Name = newNode.Name,
                Parent = newNode.Parent
            }));
        }
    }

    public class RemoveQualitativePropertyRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            QualitativeProperty oldNode = null;

            When()
                .Match<QualitativeProperty>(() => oldNode, _ => _.Version == "Old")
                .Not<QualitativeProperty>(n => n.Version == "New",
                    n => n.Name == oldNode.Name,
                    n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveQualitativeProperty()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class EditQualitativePropertyRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            QualitativeProperty oldNode = null;
            QualitativeProperty newNode = null;

            When()
                .Match<QualitativeProperty>(() => oldNode, _ => _.Version == "Old")
                .Match<QualitativeProperty>(() => newNode, _ => _.Version == "New" && _.Name == oldNode.Name && _.InnerText != oldNode.InnerText);

            Then()
                .Do(ctx => ctx.Insert(new EditQualitativeProperty()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class AddQuantitativePropertyRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            QuantitativeProperty newNode = null;

            When()
                .Match<QuantitativeProperty>(() => newNode, _ => _.Version == "New")
                .Not<QuantitativeProperty>(n => n.Version == "Old",
                    n => n.Name == newNode.Name,
                    n => n.Parent.Name == newNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddQuantitativeProperty()
            {
                Name = newNode.Name,
                Parent = newNode.Parent
            }));
        }
    }

    public class RemoveQuantitativePropertyRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            QuantitativeProperty oldNode = null;

            When()
                .Match<QuantitativeProperty>(() => oldNode, _ => _.Version == "Old")
                .Not<QuantitativeProperty>(n => n.Version == "New",
                    n => n.Name == oldNode.Name,
                    n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveQuantitativeProperty()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class EditQuantitativePropertyRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            QuantitativeProperty oldNode = null;
            QuantitativeProperty newNode = null;

            When()
                .Match<QuantitativeProperty>(() => oldNode, _ => _.Version == "Old")
                .Match<QuantitativeProperty>(() => newNode, _ => _.Version == "New" && _.Name == oldNode.Name && _.InnerText != oldNode.InnerText);

            Then()
                .Do(ctx => ctx.Insert(new EditQuantitativeProperty()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class AddHardGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            HardGoal newNode = null;

            When()
                .Match<HardGoal>(() => newNode, _ => _.Version == "New")
                .Not<HardGoal>(n => n.Version == "Old",
                    n => n.Name == newNode.Name,
                    n => n.Parent.Name == newNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddHardGoal()
            {
                Name = newNode.Name,
                Parent = newNode.Parent
            }));
        }
    }

    public class RemoveHardGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            HardGoal oldNode = null;

            When()
                .Match<HardGoal>(() => oldNode, _ => _.Version == "Old")
                .Not<HardGoal>(n => n.Version == "New",
                    n => n.Name == oldNode.Name,
                    n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveHardGoal()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class EditHardGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            HardGoal oldNode = null;
            HardGoal newNode = null;

            When()
                .Match<HardGoal>(() => oldNode, _ => _.Version == "Old")
                .Match<HardGoal>(() => newNode, _ => _.Version == "New" && _.Name == oldNode.Name && _.InnerText != oldNode.InnerText);

            Then()
                .Do(ctx => ctx.Insert(new EditHardGoal()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class AddSoftGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            SoftGoal newNode = null;

            When()
                .Match<SoftGoal>(() => newNode, _ => _.Version == "New")
                .Not<SoftGoal>(n => n.Version == "Old",
                    n => n.Name == newNode.Name,
                    n => n.Parent.Name == newNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddSoftGoal()
            {
                Name = newNode.Name,
                Parent = newNode.Parent
            }));
        }
    }

    public class RemoveSoftGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            SoftGoal oldNode = null;

            When()
                .Match<SoftGoal>(() => oldNode, _ => _.Version == "Old")
                .Not<SoftGoal>(n => n.Version == "New",
                    n => n.Name == oldNode.Name,
                    n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveSoftGoal()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class EditSoftGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            SoftGoal oldNode = null;
            SoftGoal newNode = null;

            When()
                .Match<SoftGoal>(() => oldNode, _ => _.Version == "Old")
                .Match<SoftGoal>(() => newNode, _ => _.Version == "New" && _.Name == oldNode.Name && _.InnerText != oldNode.InnerText);

            Then()
                .Do(ctx => ctx.Insert(new EditSoftGoal()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class AddCompositeGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            CompositeGoal newNode = null;

            When()
                .Match<CompositeGoal>(() => newNode, _ => _.Version == "New")
                .Not<CompositeGoal>(n => n.Version == "Old",
                    n => n.Name == newNode.Name,
                    n => n.Parent.Name == newNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddCompositeGoal()
            {
                Name = newNode.Name,
                Parent = newNode.Parent
            }));
        }
    }

    public class RemoveCompositeGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            CompositeGoal oldNode = null;

            When()
                .Match<CompositeGoal>(() => oldNode, _ => _.Version == "Old")
                .Not<CompositeGoal>(n => n.Version == "New",
                    n => n.Name == oldNode.Name,
                    n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveCompositeGoal()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }

    public class EditCompositeGoalRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            CompositeGoal oldNode = null;
            CompositeGoal newNode = null;

            When()
                .Match<CompositeGoal>(() => oldNode, _ => _.Version == "Old")
                .Match<CompositeGoal>(() => newNode, _ => _.Version == "New" && _.Name == oldNode.Name && _.InnerText != oldNode.InnerText);

            Then()
                .Do(ctx => ctx.Insert(new EditCompositeGoal()
            {
                Name = oldNode.Name,
                Parent = oldNode.Parent
            }));
        }
    }
}
