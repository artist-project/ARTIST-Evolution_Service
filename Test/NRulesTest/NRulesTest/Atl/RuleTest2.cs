using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRulesTest.Atl
{
    public class Node
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Context { get; set; }
        public Node Parent { get; set; }
    }

    public class Concept
    {
        private sealed class NameEqualityComparer : IEqualityComparer<Concept>
        {
            public bool Equals(Concept x, Concept y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Concept obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Concept> NameComparerInstance = new NameEqualityComparer();

        public static IEqualityComparer<Concept> NameComparer
        {
            get { return NameComparerInstance; }
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Context { get; set; }
        public Node Parent { get; set; }
        //public Model Source { get; set; }
        //public Model Target { get; set; }
    }

    public class InModel
    {
        public Model Model { get; set; }
        public string Context { get; set; }
        public Concept Parent { get; set; }
    }

    public class OutModel
    {
        public Model Model { get; set; }
        public string Context { get; set; }
        public Concept Parent { get; set; }
    }

    public class Model
    {
        public string Name { get; set; }
        public string MetaModel { get; set; }
    }

    public class AddConcept : ChangeDefinition
    {
        public string Name { get; set; }
        public Node Parent { get; set; }
    }

    public class AddSourceOfConcept : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class RemoveSourceOfConcept : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class ModifySourceOfConcept : ChangeDefinition
    {
        public string Name { get; set; }
        public string OldSource { get; set; }
        public string NewSource { get; set; }
    }

    public class ModifyTargetOfConcept : ChangeDefinition
    {
        public string Name { get; set; }
        public string OldTarget { get; set; }
        public string NewTarget { get; set; }
    }

    public class RemoveConcept : ChangeDefinition
    {
        public string Name { get; set; }
        public Node Parent { get; set; }
    }

    public class AddNode : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class RemoveNode : ChangeDefinition
    {
        public string Name { get; set; }
    }

    public class MoveConcept : ChangeDefinition
    {
        public string Name { get; set; }
        public string OldParent { get; set; }
        public string NewParent { get; set; }
    }

    //public class Edge
    //{
    //    public string Name { get; set; }
    //    public string From { get; set; }
    //    public string To { get; set; }
    //    public string Context { get; set; }
    //}

    public class AddNodeRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Node oldNode = null;

            When()
                .Match<Node>(() => oldNode, _ => _.Context == "New")
                .Not<Node>(n => n.Context == "Old", n => n.Name == oldNode.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddNode() { Name = oldNode.Name }));
        }
    }

    public class RemoveNodeRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Node oldNode = null;

            When()
                .Match<Node>(() => oldNode, _ => _.Context == "Old")
                .Not<Node>(n => n.Context == "New", n => n.Name == oldNode.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveNode() { Name = oldNode.Name }));
        }
    }

    public class AddConceptRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Concept oldNode = null;

            When()
                .Match<Concept>(() => oldNode, _ => _.Context == "New")
                .Not<Concept>(n => n.Context == "Old", n => n.Name == oldNode.Name, n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddConcept() { Name = oldNode.Name, Parent = oldNode.Parent }));
        }
    }

    public class RemoveConceptRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Concept oldNode = null;

            When()
                .Match<Concept>(() => oldNode, _ => _.Context == "Old")
                .Not<Concept>(n => n.Context == "New", n => n.Name == oldNode.Name, n => n.Parent.Name == oldNode.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveConcept() { Name = oldNode.Name, Parent = oldNode.Parent }));
        }
    }

    public class AddSourceOfConceptRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            InModel inModelNew = null;

            When()
                .Match<InModel>(() => inModelNew, _ => _.Context == "New")
                .Not<InModel>(_ => _.Context == "Old", x => x.Parent.Name == inModelNew.Parent.Name, y => y.Model.Name == inModelNew.Model.Name);

            Then()
                .Do(ctx => ctx.Insert(new AddSourceOfConcept() { Name = inModelNew.Model.Name }));
        }
    }

    public class RemoveSourceOfConceptRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            InModel inModelOld = null;
            
            When()
                .Match<InModel>(() => inModelOld, _ => _.Context == "Old")
                .Not<InModel>(_ => _.Context == "New", _ => _.Parent.Name == inModelOld.Parent.Name, model => model.Model.Name == inModelOld.Model.Name);

            Then()
                .Do(ctx => ctx.Insert(new RemoveSourceOfConcept() { Name = inModelOld.Model.Name }));
        }
    }

    public class RefactorConceptIntoLibrary : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            AddNode node = null;
            AddConcept add = null;
            RemoveConcept remove = null;

            When()
                .Match<AddNode>(() => node)
                .Match<AddConcept>(() => add, _ => _.Parent.Name == node.Name)
                .Match<RemoveConcept>(() => remove, _ => _.Name == add.Name, _ => _.Parent.Name != add.Parent.Name);

            Then()
                .Do(ctx => ctx.Insert(new MoveConcept() { Name = add.Name, OldParent = remove.Parent.Name, NewParent = add.Parent.Name }));
        }
    }

    public class ModifySourceOfConceptRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Concept oldConcept = null;
            Concept newConcept = null;
            InModel inModelOld = null;
            InModel inModelNew = null;

            When()
                .Match<Concept>(() => oldConcept, concept => concept.Context == "Old")
                .Match<Concept>(() => newConcept, _ => _.Context == "New")
                .Match<InModel>(() => inModelOld, _ => _.Parent == oldConcept)
                .Match<InModel>(() => inModelNew, _ => _.Parent == newConcept, model => model.Model.Name == inModelOld.Model.Name && model.Model.MetaModel != inModelOld.Model.MetaModel);

            Then()
                .Do(ctx => ctx.Insert(new ModifySourceOfConcept() { Name = newConcept.Name, OldSource = inModelOld.Model.MetaModel, NewSource = inModelNew.Model.MetaModel }));
        }
    }

    public class ModifyTargetOfConceptRule : NRules.Fluent.Dsl.Rule
    {
        public override void Define()
        {
            Concept oldConcept = null;
            Concept newConcept = null;
            OutModel outModelOld = null;
            OutModel outModelNew = null;

            When()
                .Match<Concept>(() => oldConcept, concept => concept.Context == "Old")
                .Match<Concept>(() => newConcept, _ => _.Context == "New")
                .Match<OutModel>(() => outModelOld, _ => _.Parent == oldConcept)
                .Match<OutModel>(() => outModelNew, _ => _.Parent == newConcept, model => model.Model.Name == outModelOld.Model.Name && model.Model.MetaModel != outModelOld.Model.MetaModel);

            Then()
                .Do(ctx => ctx.Insert(new ModifySourceOfConcept() { Name = newConcept.Name, OldSource = outModelOld.Model.MetaModel, NewSource = outModelNew.Model.MetaModel }));
        }
    }
}
