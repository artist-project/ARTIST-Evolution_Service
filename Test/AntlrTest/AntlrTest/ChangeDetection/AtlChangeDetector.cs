using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Tree;

namespace AntlrTest.ChangeDetection
{
    //public class AtlChangeDetector : IChangeDetector
    //{
    //    private List<ChangeDefinition> changes;

    //    public AtlChangeDetector()
    //    {
    //        changes = new List<ChangeDefinition>();
    //    }

    //    public IEnumerable<ChangeDefinition> Changes()
    //    {
    //        return changes;
    //    }

    //    public void ComputeChanges(string oldModelFileName, string newModelFileName)
    //    {
    //        if (File.Exists(oldModelFileName) && File.Exists(newModelFileName))
    //        {
    //            var oldContent = File.ReadAllText(oldModelFileName);
    //            var newContent = File.ReadAllText(newModelFileName);

    //            if (oldContent.Equals(newContent))
    //                return;

    //            var oldModel = ParseModel(oldContent);
    //            var newModel = ParseModel(newContent);

    //            ComputeChanges(oldModel, newModel);
    //        }
    //    }

    //    public void ComputeChanges(ATLParser.UnitContext oldModel, ATLParser.UnitContext newModel)
    //    {
    //        var oldTree = oldModel.GetChild(0);
    //        var newTree = newModel.GetChild(0);

    //        if (oldModel.module() != null && newModel.module() != null)
    //        {
    //            ComputeChanges(oldModel.module(), oldModel.module());
    //        }
    //        else if (oldModel.library() != null && newModel.library() != null)
    //        {
    //            ComputeChanges(oldModel.library(), newModel.library());
    //        }
    //        else if (oldModel.query() != null && newModel.query() != null)
    //        {
    //            ComputeChanges(oldModel.query(), newModel.query());
    //        }
    //    }

    //    public void ComputeChanges(ATLParser.ModuleContext oldModule, ATLParser.ModuleContext newModule)
    //    {
    //        oldModule.IDENTIFIER()
    //    }

    //    public void ComputeChanges(ATLParser.LibraryContext oldLibrary, ATLParser.LibraryContext newLibrary)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ComputeChanges(ATLParser.QueryContext oldQuery, ATLParser.QueryContext newQuery)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public List<Change> ComputeChanges(List<IAtlElement> oldModel, List<IAtlElement> newModel)
    //    //{
    //    //    List<Change> changes = new List<Change>();

    //    //    // Get Items in oldModel that are not in newModel i.e. the removed elements
    //    //    var removals = oldModel.Except(newModel).ToList();
    //    //    changes.AddRange(removals.Select(_ => new Change() { Operation = ChangeOperation.RemoveElement, Arguments = new List<string>() { _.Name } }));

    //    //    // Get the items in newModel that are not in oldModel i.e. the added elements
    //    //    var additions = newModel.Except(oldModel);
    //    //    changes.AddRange(additions.Select(_ => new Change() { Operation = ChangeOperation.RemoveElement, Arguments = new List<string>() { _.Name } }));





    //    //    return changes;
    //    //}

    //    private ATLParser.UnitContext ParseModel(string content)
    //    {
    //        AntlrInputStream input = new AntlrInputStream(content);
    //        ATLLexer lexer = new ATLLexer(input);
    //        CommonTokenStream tokens = new CommonTokenStream(lexer);
    //        ATLParser parser = new ATLParser(tokens);

    //        return (ATLParser.UnitContext)parser.unit();
    //    }

    //}
}
