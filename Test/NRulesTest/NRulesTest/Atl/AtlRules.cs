using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NRules.Fluent.Dsl;

namespace NRulesTest.Atl
{
    //public class RefactorHelpersIntoLibraryRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        AddLibraryRef add = null;
    //        List<RemoveHelper> remove = null;

    //        When()
    //            .Match<AddLibraryRef>(() => add)
    //            .Collect<RemoveHelper>(() => remove);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RefactorHelpersIntoLibrary() { reference = add.reference, helpers = remove.Select(_ => _.reference).ToList() }));
    //    }
    //}

    //public class RenameRuleRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        AddRule add = null;
    //        RemoveRule remove = null;

    //        When()
    //            .Match<AddRule>(() => add)
    //            .Match<RemoveRule>(() => remove, _ => remove.reference.Body == add.reference.Body);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RenameRule() { OldName = remove.reference.Name, NewName = add.reference.Name }));
    //    }
    //}

    //public class RenameHelperRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        AddHelper add = null;
    //        RemoveHelper remove = null;

    //        When()
    //            .Match<AddHelper>(() => add)
    //            .Match<RemoveHelper>(() => remove, _ => remove.reference.Body == add.reference.Body);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RenameHelper() { OldName = remove.reference.Name, NewName = add.reference.Name }));
    //    }
    //}


    // ************************************************************************

    //public class RenameModuleRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Module oldModule = null;
    //        Module newModule = null;

    //        When()
    //            .Match<Module>(() => oldModule, _ => oldModule.Context == "old")
    //            .Match<Module>(() => newModule, _ => newModule.Context == "new" && oldModule.Id != newModule.Id);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RenameModule() { OldName = oldModule.Id, NewName = newModule.Id }));
    //    }
    //}

    //[Name("AddInput")]
    //public class AddInputRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        List<HasInput> inputs = null;

    //        When()
    //            .Collect<HasInput>(() => inputs);

    //        Then()
    //            .Do(ctx => Process(inputs).ForEach(ctx.Insert));
    //    }

    //    private List<AddHasInput> Process(List<HasInput> i)
    //    {
    //        var adds = new List<AddHasInput>();

    //        List<HasInput> oldInputs = i.Where(_ => _.Context == "old").ToList();
    //        List<HasInput> newInputs = i.Where(_ => _.Context == "new").ToList();

    //        List<string> oldNames = oldInputs.Select(_ => ((Atl.Model)_.Target).Name).ToList();

    //        foreach (HasInput x in newInputs)
    //        {
    //            if (!oldNames.Contains(((Atl.Model)x.Target).Name))
    //            {
    //                adds.Add(new AddHasInput() { reference = x });
    //            }
    //        }

    //        return adds;
    //    }
    //}

    //public class RemoveInputRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        List<HasInput> inputs = null;

    //        When()
    //            .Collect<HasInput>(() => inputs);

    //        Then()
    //            .Do(ctx => Process(inputs).ForEach(ctx.Insert));
    //    }

    //    private List<RemoveHasInput> Process(List<HasInput> i)
    //    {
    //        var removes = new List<RemoveHasInput>();

    //        List<HasInput> oldInputs = i.Where(_ => _.Context == "old").ToList();
    //        List<HasInput> newInputs = i.Where(_ => _.Context == "new").ToList();

    //        List<string> newNames = newInputs.Select(_ => ((Atl.Model)_.Target).Name).ToList();

    //        foreach (HasInput x in oldInputs)
    //        {
    //            if (!newNames.Contains(((Atl.Model)x.Target).Name))
    //            {
    //                removes.Add(new RemoveHasInput() { reference = x });
    //            }
    //        }

    //        return removes;
    //    }
    //}

    //[Name("RenameInput")]
    //public class RenameInputRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        HasInput input = null;
    //        HasInput input2 = null;

    //        When()
    //            .Match<HasInput>(() => input, _ => _.Context == "new")
    //            .Match<HasInput>(() => input2,
    //                _ => _.Context == "old" && ((Atl.Model)_.Target).Name == ((Atl.Model)input.Target).Name && ((Atl.Model)_.Target).MetaModel != ((Atl.Model)input.Target).MetaModel);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RenameHasInput()));
    //    }
    //}

    //[Name("AddOutput")]
    //public class AddOutputRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        List<HasOutput> outputs = null;

    //        When()
    //            .Collect<HasOutput>(() => outputs);

    //        Then()
    //            .Do(ctx => Process(outputs).ForEach(ctx.Insert));
    //    }

    //    private List<AddHasInput> Process(List<HasOutput> i)
    //    {
    //        var adds = new List<AddHasInput>();

    //        List<HasOutput> oldOutputs = i.Where(_ => _.Context == "old").ToList();
    //        List<HasOutput> newOutputs = i.Where(_ => _.Context == "new").ToList();

    //        List<string> oldNames = oldOutputs.Select(_ => ((Atl.Model)_.Target).Name).ToList();

    //        foreach (HasOutput x in newOutputs)
    //        {
    //            if (!oldNames.Contains(((Atl.Model)x.Target).Name))
    //            {
    //                adds.Add(new AddHasInput());
    //            }
    //        }

    //        return adds;
    //    }
    //}

    //[Name("RemoveHelper")]
    //public class RemoveHelperRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Helper helper = null;
    //        Helper newHelper = null;

    //        When()
    //            .Match<Helper>(() => helper, _ => _.Context == "old")
    //            .Match<Helper>(() => newHelper, _ => _.Context == "new", 

    //        Then()
    //            .Do(ctx => Process(helpers).ForEach(ctx.Insert));
    //    }

    //    private List<RemoveHelper> Process(List<Helper> i)
    //    {
    //        var removes = new List<RemoveHelper>();

    //        //List<string> newNames = j.Select(_ => ((Atl.Model)_.Target).Name).ToList();

    //        //foreach (HasInput x in i)
    //        //{
    //        //    if (!newNames.Contains(((Atl.Model)x.Target).Name))
    //        //    {
    //        //        removes.Add(new RemoveHasInput() { reference = x });
    //        //    }
    //        //}

    //        return removes;
    //    }
    //}

    //*************************************************************************

    //public class AddConceptRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Concept c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New" && _.Name == oldModel.Name)

    //            .Match<Concept>(() => c, _ => !oldModel.Concepts.Contains(_, Concept.IdComparer) && newModel.Concepts.Contains(_, Concept.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new AddConcept() { Name = c.Id }));
    //    }
    //}

    //public class RemoveConceptRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Concept c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New" && _.Name == oldModel.Name)
    //            .Match<Concept>(() => c, _ => oldModel.Concepts.Contains(_, Concept.IdComparer) && !newModel.Concepts.Contains(_, Concept.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new RemoveConcept() { Name = c.Id }));
    //    }
    //}

    //public class AddRelationRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Relation c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New")
    //        //.Match<Relation>(() => c, _ => _.Model != oldModel && _.Model == newModel);
    //        .Match<Relation>(() => c, _ => !oldModel.Relations.Contains(_, Relation.IdComparer) && newModel.Relations.Contains(_, Relation.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new AddRelation() { Name = c.Id, Relation = c, NewModel = newModel }));
    //    }
    //}

    //public class AddImportRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Model l = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New" && _.Name == oldModel.Name)
    //            .Match<Model>(() => l, _ => !oldModel.Imports.Contains(_, Relation.IdComparer) && newModel.Imports.Contains(_, Library.NameComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new AddImport() { Name = l.Name, Model = newModel, Library = l }));
    //    }
    //}

    //public class RemoveRelationRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Relation c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New")
    //        //.Match<Relation>(() => c, _ => _.Model == oldModel && _.Model != newModel);
    //        .Match<Relation>(() => c, _ => oldModel.Relations.Contains(_, Relation.IdComparer) && !newModel.Relations.Contains(_, Relation.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new RemoveRelation() { Name = c.Id, Relation = c, OldModel = oldModel }));
    //    }
    //}

    //public class RefactorHelperIntoLibraryRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        AddImport l = null;
    //        RemoveRelation r = null;
    //        AddRelation r2 = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New" && _.Name == oldModel.Name)
    //            .Match<AddImport>(() => l, _ => _.Model == newModel)
    //            .Match<AddRelation>(() => r2, _ => l.Library.Relations.Contains(r2.Relation))
    //            .Match<RemoveRelation>(() => r, _ => _.Relation.Model == oldModel && r.Name == r2.Name);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RefactorRelationIntoLibrary() { Library = l.Name, Relation = r.Name }));
    //    }
    //}

    //public class RefactorHelpersIntoLibraryRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        AddImport l = null;
    //        RemoveRelation r = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == "Old")
    //            .Match<Model>(() => newModel, _ => _.Context == "New" && _.Name == oldModel.Name)
    //            .Match<AddImport>(() => l, _ => _.Model == newModel)
    //            .Match<RemoveRelation>(() => r, _ => _.Relation.Model == oldModel);

    //        Then()
    //            .Do(ctx => ctx.Insert(new RefactorRelationIntoLibrary() { Library = l.Name, Relation = r.Name }));
    //    }
    //}

    //public class AddConceptRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Concept c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == ContextType.Old)
    //            .Match<Model>(() => newModel, _ => _.Context == ContextType.New)
    //            .Match<Concept>(() => c, _ => !oldModel.Concepts.Contains(_, Concept.IdComparer) && newModel.Concepts.Contains(_, Concept.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new Add() { Name = c.Id }));
    //    }
    //}

    //public class RemoveConceptRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Concept c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == ContextType.Old)
    //            .Match<Model>(() => newModel, _ => _.Context == ContextType.New)
    //            .Match<Concept>(() => c, _ => oldModel.Concepts.Contains(_, Concept.IdComparer) && !newModel.Concepts.Contains(_, Concept.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new Remove() { Name = c.Id }));
    //    }
    //}

    //public class AddRelationRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Relation c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == ContextType.Old)
    //            .Match<Model>(() => newModel, _ => _.Context == ContextType.New)
    //            .Match<Relation>(() => c, _ => !oldModel.Relations.Contains(_, Relation.IdComparer) && newModel.Relations.Contains(_, Relation.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new Add() { Name = c.Id }));
    //    }
    //}

    //public class RemoveRelationRule : NRules.Fluent.Dsl.Rule
    //{
    //    public override void Define()
    //    {
    //        Model oldModel = null;
    //        Model newModel = null;
    //        Relation c = null;

    //        When()
    //            .Match<Model>(() => oldModel, _ => _.Context == ContextType.Old)
    //            .Match<Model>(() => newModel, _ => _.Context == ContextType.New)
    //            .Match<Relation>(() => c, _ => oldModel.Relations.Contains(_, Relation.IdComparer) && !newModel.Relations.Contains(_, Relation.IdComparer));

    //        Then()
    //            .Do(ctx => ctx.Insert(new Remove() { Name = c.Id }));
    //    }
    //}
}
