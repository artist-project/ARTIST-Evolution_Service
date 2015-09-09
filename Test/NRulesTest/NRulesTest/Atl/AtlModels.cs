using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRulesTest.Atl
{
    //public class LibraryRef
    //{
    //    public string Name { get; set; }
    //}

    //public class Helper
    //{
    //    public string Name { get; set; }
    //    public string Body { get; set; }
    //}

    //public class Rule
    //{
    //    public string Name { get; set; }
    //    public string Body { get; set; }
    //}

    //public class Model
    //{
    //    private sealed class NameEqualityComparer : IEqualityComparer<Model>
    //    {
    //        public bool Equals(Model x, Model y)
    //        {
    //            if (ReferenceEquals(x, y)) return true;
    //            if (ReferenceEquals(x, null)) return false;
    //            if (ReferenceEquals(y, null)) return false;
    //            if (x.GetType() != y.GetType()) return false;
    //            return string.Equals(x.Name, y.Name);
    //        }

    //        public int GetHashCode(Model obj)
    //        {
    //            return (obj.Name != null ? obj.Name.GetHashCode() : 0);
    //        }
    //    }

    //    private static readonly IEqualityComparer<Model> NameComparerInstance = new NameEqualityComparer();

    //    public static IEqualityComparer<Model> NameComparer
    //    {
    //        get { return NameComparerInstance; }
    //    }

    //    public Model()
    //    {
    //        Imports = new List<Model>();
    //        Concepts = new List<Concept>();
    //        Relations = new List<Relation>();
    //    }

    //    public string Name { get; set; }
    //    public string Context { get; set; }
    //    public List<Model> Imports { get; set; }
    //    public List<Concept> Concepts { get; set; }
    //    public List<Relation> Relations { get; set; }
    //}

    //public class Concept
    //{
    //    private sealed class IdEqualityComparer : IEqualityComparer<Concept>
    //    {
    //        public bool Equals(Concept x, Concept y)
    //        {
    //            if (ReferenceEquals(x, y)) return true;
    //            if (ReferenceEquals(x, null)) return false;
    //            if (ReferenceEquals(y, null)) return false;
    //            if (x.GetType() != y.GetType()) return false;
    //            return string.Equals(x.Id, y.Id);
    //        }

    //        public int GetHashCode(Concept obj)
    //        {
    //            return (obj.Id != null ? obj.Id.GetHashCode() : 0);
    //        }
    //    }

    //    private static readonly IEqualityComparer<Concept> IdComparerInstance = new IdEqualityComparer();

    //    public static IEqualityComparer<Concept> IdComparer
    //    {
    //        get { return IdComparerInstance; }
    //    }

    //    public string Id { get; set; }
    //    public Model Model { get; set; }
    //    public string Context { get; set; }
    //}

    //public class Relation
    //{
    //    private sealed class IdEqualityComparer : IEqualityComparer<Relation>
    //    {
    //        public bool Equals(Relation x, Relation y)
    //        {
    //            if (ReferenceEquals(x, y)) return true;
    //            if (ReferenceEquals(x, null)) return false;
    //            if (ReferenceEquals(y, null)) return false;
    //            if (x.GetType() != y.GetType()) return false;
    //            return string.Equals(x.Id, y.Id);
    //        }

    //        public int GetHashCode(Relation obj)
    //        {
    //            return (obj.Id != null ? obj.Id.GetHashCode() : 0);
    //        }
    //    }

    //    private static readonly IEqualityComparer<Relation> IdComparerInstance = new IdEqualityComparer();

    //    public static IEqualityComparer<Relation> IdComparer
    //    {
    //        get { return IdComparerInstance; }
    //    }

    //    public string Id { get; set; }
    //    public Model Model { get; set; }
    //    public string Context { get; set; }
    //}

    //public class Library
    //{
    //    public Library()
    //    {
    //        Relations = new List<Relation>();
    //    }

    //    private sealed class NameEqualityComparer : IEqualityComparer<Library>
    //    {
    //        public bool Equals(Library x, Library y)
    //        {
    //            if (ReferenceEquals(x, y)) return true;
    //            if (ReferenceEquals(x, null)) return false;
    //            if (ReferenceEquals(y, null)) return false;
    //            if (x.GetType() != y.GetType()) return false;
    //            return string.Equals(x.Name, y.Name);
    //        }

    //        public int GetHashCode(Library obj)
    //        {
    //            return (obj.Name != null ? obj.Name.GetHashCode() : 0);
    //        }
    //    }

    //    private static readonly IEqualityComparer<Library> NameComparerInstance = new NameEqualityComparer();

    //    public static IEqualityComparer<Library> NameComparer
    //    {
    //        get { return NameComparerInstance; }
    //    }

    //    public string Name { get; set; }
    //    public string Context { get; set; }
    //    public List<Relation> Relations { get; set; }
    //}

    //public class Module
    //{
    //    public string Id { get; set; }
    //    public string Context { get; set; }
    //    public string Name { get; set; }
    //    public string Mode { get; set; }

    //    public List<string> Imports { get; set; }
    //}

    //public class Model
    //{
    //    public string Id { get; set; }
    //    public string Context { get; set; }
    //    public string Name { get; set; }
    //    public string MetaModel { get; set; }
    //}

    //public class HasInput
    //{
    //    public string ID { get; set; }
    //    public string Context { get; set; }
    //    public Module Source { get; set; }
    //    public Model Target { get; set; }
    //}

    //public class HasOutput
    //{
    //    public string ID { get; set; }
    //    public string Context { get; set; }
    //    public Module Source { get; set; }
    //    public Model Target { get; set; }
    //}

    //public class HasHelper
    //{
    //    public string ID { get; set; }
    //    public string Context { get; set; }
    //    public Module Source { get; set; }
    //    public Helper Target { get; set; }
    //}

    //public class Helper
    //{
    //    public string Id { get; set; }
    //    public string Context { get; set; }
    //}

    //public class Rule
    //{
    //    public string Id { get; set; }
    //    public string Context { get; set; }
    //}

}
