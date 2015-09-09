using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntlrTest.ATL.Definitions;
using AntlrTest.ATL.Domain;

namespace AntlrTest.ATL.Rules
{
    //public class AddNodeRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Node oldNode = null;

    //        When()
    //            .Match<Node>(() => oldNode, _ => _.Version == "New")
    //            .Not<Node>(n => n.Version == "Old", n => n.Name == oldNode.Name);

    //        Then()
    //            .Do(ctx => ctx.Insert(new AddNode() { Name = oldNode.Name }));
    //    }
    //}

    //public class RemoveNodeRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Node oldNode = null;

    //        When()
    //            .Match<Node>(() => oldNode, _ => _.Version == "Old")
    //            .Not<Node>(n => n.Version == "New", n => n.Name == oldNode.Name);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RemoveNode() { Name = oldNode.Name }));
    //    }
    //}

    public class AddRuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Rule oldNode = null;

            When()
                .Match<Rule>(() => oldNode, _ => _.Version == "New")
                .Not<Rule>(n => n.Version == "Old", n => n.Name == oldNode.Name, n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddRule() { Name = oldNode.Name, Parent = oldNode.Parent }));
        }
    }

    public class RemoveRuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Rule oldNode = null;

            When()
                .Match<Rule>(() => oldNode, _ => _.Version == "Old")
                .Not<Rule>(n => n.Version == "New", n => n.Name == oldNode.Name, n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveRule() { Name = oldNode.Name, Parent = oldNode.Parent }));
        }
    }

    public class AddSourceOfModuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            SourceModel inModelNew = null;

            When()
                .Match<SourceModel>(() => inModelNew, _ => _.Version == "New")
                .Not<SourceModel>(_ => _.Version == "Old", x => x.Parent.Name == inModelNew.Parent.Name, y => y.Model.Name == inModelNew.Model.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddSourceOfModule() { Name = inModelNew.Model.Name }));
        }
    }

    public class RemoveSourceOfModuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            SourceModel inModelOld = null;

            When()
                .Match<SourceModel>(() => inModelOld, _ => _.Version == "Old")
                .Not<SourceModel>(_ => _.Version == "New", _ => _.Parent.Name == inModelOld.Parent.Name, model => model.Model.Name == inModelOld.Model.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveSourceOfModule() { Name = inModelOld.Model.Name }));
        }
    }

    public class AddTargetOfModuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            TargetModel outModelNew = null;

            When()
                .Match<TargetModel>(() => outModelNew, _ => _.Version == "New")
                .Not<TargetModel>(_ => _.Version == "Old", x => x.Parent.Name == outModelNew.Parent.Name, y => y.Model.Name == outModelNew.Model.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddTargetOfModule() { Name = outModelNew.Model.Name }));
        }
    }

    public class RemoveTargetOfModuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            TargetModel outModelOld = null;

            When()
                .Match<TargetModel>(() => outModelOld, _ => _.Version == "Old")
                .Not<TargetModel>(_ => _.Version == "New", _ => _.Parent.Name == outModelOld.Parent.Name, model => model.Model.Name == outModelOld.Model.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveTargetOfModule() { Name = outModelOld.Model.Name }));
        }
    }

    public class ModifySourceOfModuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Module oldModule = null;
            Module newModule = null;
            SourceModel inModelOld = null;
            SourceModel inModelNew = null;

            When()
                .Match<Module>(() => oldModule, concept => concept.Version == "Old")
                .Match<Module>(() => newModule, _ => _.Version == "New")
                .Match<SourceModel>(() => inModelOld, _ => _.Parent == oldModule)
                .Match<SourceModel>(() => inModelNew, _ => _.Parent == newModule, model => model.Model.Name == inModelOld.Model.Name && model.Model.MetaModel != inModelOld.Model.MetaModel);

            Then()
                .Do(ctx => ctx.Insert(new ModifySourceOfModule() { Name = newModule.Name, OldSource = inModelOld.Model.MetaModel, NewSource = inModelNew.Model.MetaModel }));
        }
    }

    public class ModifyTargetOfModuleRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Module oldModule = null;
            Module newModule = null;
            TargetModel outModelOld = null;
            TargetModel outModelNew = null;

            When()
                .Match<Module>(() => oldModule, concept => concept.Version == "Old")
                .Match<Module>(() => newModule, _ => _.Version == "New")
                .Match<TargetModel>(() => outModelOld, _ => _.Parent == oldModule)
                .Match<TargetModel>(() => outModelNew, _ => _.Parent == newModule, model => model.Model.Name == outModelOld.Model.Name && model.Model.MetaModel != outModelOld.Model.MetaModel);

            Then()
                .Do(ctx => ctx.Insert(new ModifyTargetOfModule() { Name = newModule.Name, OldTarget = outModelOld.Model.MetaModel, NewTarget = outModelNew.Model.MetaModel }));
        }
    }

    //public class RefactorConceptIntoLibrary : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        AddNode node = null;
    //        AddConcept add = null;
    //        RemoveConcept remove = null;

    //        When()
    //            .Match<AddNode>(() => node)
    //            .Match<AddConcept>(() => add, _ => _.Parent.Name == node.Name)
    //            .Match<RemoveConcept>(() => remove, _ => _.Name == add.Name, _ => _.Parent.Name != add.Parent.Name);

    //        Then()
    //            .Do(ctx => ctx.Insert(new MoveConcept() { Name = add.Name, OldParent = remove.Parent.Name, NewParent = add.Parent.Name }));
    //    }
    //}
}
