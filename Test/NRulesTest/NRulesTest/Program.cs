using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NRules;
using NRules.Fluent;
using NRulesTest.Atl;

namespace NRulesTest
{
    class Program
    {

        public Program()
        {

        }

        public void RuleTest2()
        {
            ModelProcessor processor = new ModelProcessor();

            List<object> session = new List<object>();

            var a_n1 = new Node() { Name = "MyModel", Context = "Old", Type = "Model" };
            var a_n2 = new Concept() { Name = "Helper1", Context = "Old", Type = "Helper", Parent = a_n1 };
            var a_n3 = new Concept() { Name = "Helper2", Context = "Old", Type = "Helper", Parent = a_n1 };
            var a_n4 = new Concept() { Name = "Helper5", Context = "Old", Type = "Helper", Parent = a_n1 };

            var a_m1 = new InModel() { Model = new Model() { Name = "IN", MetaModel = "Families" }, Parent = a_n2, Context = "Old" };

            //var a_e1 = new Edge() { Name = "hasHelper", Context = "Old", From = "MyModel", To = "Helper1" };
            //var a_e2 = new Edge() { Name = "hasHelper", Context = "Old", From = "MyModel", To = "Helper2" };

            session.Add(a_n1);
            session.Add(a_n2);
            session.Add(a_n3);
            session.Add(a_n4);
            session.Add(a_m1);
            //session.Insert(a_e1);
            //session.Insert(a_e2);

            var b_n1 = new Node() { Name = "MyModel", Context = "New", Type = "Model" };
            var b_n5 = new Node() { Name = "MyLibrary", Context = "New", Type = "Library" };
            var b_n2 = new Concept() { Name = "Helper1", Context = "New", Type = "Helper", Parent = b_n1 };
            var b_n3 = new Concept() { Name = "Helper2", Context = "New", Type = "Helper", Parent = b_n5 };
            var b_n4 = new Concept() { Name = "Helper3", Context = "New", Type = "Helper", Parent = b_n1 };

            var b_m1 = new InModel() { Model = new Model() { Name = "IN", MetaModel = "Families2" }, Parent = b_n2, Context = "New" };
            var b_m2 = new InModel() { Model = new Model() { Name = "IN2", MetaModel = "Profile" }, Parent = b_n2, Context = "New" };

            //var b_e1 = new Edge() { Name = "hasHelper", Context = "New", From = "MyModel", To = "Helper1" };
            //var b_e2 = new Edge() { Name = "hasHelper", Context = "New", From = "MyLibrary", To = "Helper2" };
            //var b_e3 = new Edge() { Name = "hasImport", Context = "New", From = "MyModel", To = "MyLibrary" };
            //var b_e4 = new Edge() { Name = "hasHelper", Context = "New", From = "MyModel", To = "Helper3" };

            session.Add(b_n1);
            session.Add(b_n2);
            session.Add(b_n3);
            session.Add(b_n4);
            session.Add(b_n5);
            session.Add(b_m1);
            session.Add(b_m2);
            //session.Insert(b_e1);
            //session.Insert(b_e2);
            //session.Insert(b_e3);
            //session.Insert(b_e4);

            List<ChangeDefinition> derivedFacts = processor.Process(session);
        }

        //public void RuleTest()
        //{
        //    ISession session = factory.CreateSession();

        //    var m1 = new Model() { Name = "OldModel", Context = "Old" };
        //    var m2 = new Model() { Name = "OldModel", Context = "New" };

        //    var l1 = new Model() { Name = "UML::lib", Context = "New" };

        //    var c1 = new Concept() { Id = "Concept1", Context = "Old", Model = m1 };
        //    var c2 = new Concept() { Id = "Concept2", Context = "Old", Model = m1 };
        //    var c3 = new Concept() { Id = "Concept3", Context = "Old", Model = m1 };

        //    m1.Concepts.Add(c1);
        //    m1.Concepts.Add(c2);
        //    m1.Concepts.Add(c3);

        //    var c4 = new Concept() { Id = "Concept1", Context = "New", Model = m2 };
        //    var c5 = new Concept() { Id = "Concept4", Context = "New", Model = m2 };

        //    m2.Concepts.Add(c4);
        //    m2.Concepts.Add(c5);

        //    var r1 = new Relation() { Id = "Relation1", Context = "Old", Model = m1 };
        //    var r2 = new Relation() { Id = "Relation2", Context = "Old", Model = m1 };
        //    var r3 = new Relation() { Id = "Relation3", Context = "Old", Model = m1 };

        //    m1.Relations.Add(r1);
        //    m1.Relations.Add(r2);
        //    m1.Relations.Add(r3);

        //    var r4 = new Relation() { Id = "Relation1", Context = "New", Model = m2 };
        //    var r5 = new Relation() { Id = "Relation4", Context = "New", Model = m2 };

        //    var r6 = new Relation() { Id = "Relation2", Context = "New", Model = l1 };

        //    l1.Relations.Add(r6);

        //    m2.Relations.Add(r4);
        //    m2.Relations.Add(r5);

        //    session.Insert(m1);
        //    session.Insert(m2);

        //    session.Insert(l1);

        //    session.Insert(c1);
        //    session.Insert(c2);
        //    session.Insert(c3);
        //    session.Insert(c4);
        //    session.Insert(c5);

        //    session.Insert(r1);
        //    session.Insert(r2);
        //    session.Insert(r3);
        //    session.Insert(r4);
        //    session.Insert(r5);
        //    session.Insert(r6);

        //    session.Fire();

        //    List<ChangeDefinition> derivedFacts = session.Query<ChangeDefinition>().ToList();
        //}

        //public void GraphTest()
        //{
        //    ISession session = factory.CreateSession();

        //    Atl.Module m1 = new Atl.Module() { Id = "Families2Persons", Mode = "from", Context = "old", Imports = new List<string>() };
        //    Atl.Model a = new Atl.Model() { Name = "IN", MetaModel = "Families", Context = "old" };
        //    Atl.Model b = new Atl.Model() { Name = "OUT", MetaModel = "Persons", Context = "old" };
        //    Atl.Model c = new Atl.Model() { Name = "IN2", MetaModel = "Families", Context = "old" };

        //    Atl.HasInput i1 = new Atl.HasInput() { Source = m1, Target = a, Context = "old" };
        //    Atl.HasOutput i2 = new Atl.HasOutput() { Source = m1, Target = b, Context = "old" };
        //    Atl.HasInput i3 = new Atl.HasInput() { Source = m1, Target = c, Context = "old" };

        //    Atl.Helper h1 = new Atl.Helper() { Id = "Model", Context = "old" };
        //    //Atl.hasHelper h2 = new Atl.hasHelper() { Source = m1, Target = h1, Context = "old" };

        //    //Atl.Helper h3 = new Helper() { Id = "MyHelper"  };
        //    //Atl.hasHelper h4 = new hasHelper() { Source = m1, Target = h3 };

        //    session.Insert(m1);
        //    session.Insert(a);
        //    session.Insert(b);
        //    session.Insert(c);
        //    session.Insert(i1);
        //    session.Insert(i2);
        //    session.Insert(i3);

        //    //session.Insert(h2);
        //    //session.Insert(h3);
        //    //session.Insert(h4);


        //    Atl.Module m1_n = new Atl.Module() { Id = "Families2Persons2", Mode = "from", Context = "new", Imports = new List<string>() { "UML::lib" } };
        //    Atl.Model a_n = new Atl.Model() { Name = "IN", MetaModel = "Families2", Context = "new" };
        //    Atl.Model c_n = new Atl.Model() { Name = "Profile", MetaModel = "profile", Context = "new" };
        //    Atl.Model b_n = new Atl.Model() { Name = "OUT", MetaModel = "Persons", Context = "new" };

        //    Atl.HasInput i1_n = new Atl.HasInput() { Source = m1_n, Target = a_n, Context = "new" };
        //    Atl.HasInput i3_n = new Atl.HasInput() { Source = m1_n, Target = c_n, Context = "new" };
        //    Atl.HasOutput i2_n = new Atl.HasOutput() { Source = m1_n, Target = b_n, Context = "new" };

        //    //Atl.Helper h1_n = new Helper() { Id = "Model", Context = "new"};
        //    //Atl.hasHelper h2_n = new hasHelper() { Source = m1_n, Target = h1_n, Context = "new"};

        //    session.Insert(m1_n);
        //    session.Insert(a_n);
        //    session.Insert(b_n);
        //    session.Insert(c_n);
        //    session.Insert(i1_n);
        //    session.Insert(i2_n);
        //    session.Insert(i3_n);
        //    //session.Insert(h1_n);
        //    //session.Insert(h2_n);

        //    session.Fire();

        //    List<ChangeDefinition> derivedFacts = session.Query<ChangeDefinition>().ToList();
        //}

        //public void TestRefactorHelpersIntoLibrary()
        //{
        //    ISession session = factory.CreateSession();

        //    List<object> facts = new List<object>()
        //    {
        //        new AddLibraryRef() { reference = new LibraryRef() { Name = "UML::Lib" }},
        //        new AddLibraryRef() { reference = new LibraryRef() { Name = "UML::Lib2" }},
        //        new RemoveHelper() { reference = new Helper() {Name = "getProfile", Body = "" }},
        //        new RemoveHelper() { reference = new Helper() {Name = "getClass", Body = "" }},
        //        new AddRule() { reference  = new Rule() { Name = "myNewRule", Body = "123456789" } },
        //        new AddRule() { reference  = new Rule() { Name = "myRule", Body = "abcdef" } },
        //        new RemoveRule() { reference  = new Rule() { Name = "myOldRule", Body = "123456789" } },
        //        new RemoveRule() { reference  = new Rule() { Name = "myDummyRule", Body = "blablabla" } }
        //    };

        //    foreach (var o in facts)
        //    {
        //        session.Insert(o);
        //    }

        //    session.Fire();

        //    List<ChangeDefinition> derivedFacts = session.Query<ChangeDefinition>().ToList();

        //    string result = Newtonsoft.Json.JsonConvert.SerializeObject(derivedFacts, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings() { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
        //    Console.WriteLine(result);
        //}



        static void Main(string[] args)
        {
            Program p = new Program();

            //p.TestRefactorHelpersIntoLibrary();
            //p.GraphTest();
            //p.RuleTest();
            p.RuleTest2();

            Console.ReadLine();
        }
    }
}
