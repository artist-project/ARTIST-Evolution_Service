using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrTest.ATL.Domain;

namespace AntlrTest.ATL.Visitors
{
    public class BasicAtlVisitor : ATLBaseVisitor<bool>
    {
        public BasicAtlVisitor(string context)
        {
            Model = new List<object>();
            References = new Dictionary<string, object>();
            _context = context;
        }

        public List<object> Model { get; set; }
        private Dictionary<string, object> References { get; set; }
        private Module _root;
        private readonly string _context;

        public override bool VisitModule(ATLParser.ModuleContext context)
        {
            var name = (context.IDENTIFIER() != null) ? context.IDENTIFIER().GetText() : context.STRING().GetText();

            _root = new Module() { Name = name, Version = _context };

            Model.Add(_root);
            References.Add(context.SourceInterval.ToString(), _root);

            return base.VisitModule(context);
        }

        public override bool VisitTransformationMode(ATLParser.TransformationModeContext context)
        {
            var parent = _root as Module;

            if (parent == null) return base.VisitTransformationMode(context);

            var mode = context.GetText();
            parent.Mode = mode == "refining" ? TransformationMode.Refactoring : TransformationMode.Base;

            return base.VisitTransformationMode(context);
        }

        public override bool VisitSourceModelPattern(ATLParser.SourceModelPatternContext context)
        {
            foreach (var m in context.oclModel())
            {
                var model = ParseOclModelContext(m);
                var source = new SourceModel() { Model = model, Parent = _root, Version = _context };
                Model.Add(source);
            }

            return base.VisitSourceModelPattern(context);
        }

        public override bool VisitTargetModelPattern(ATLParser.TargetModelPatternContext context)
        {
            foreach (var m in context.oclModel())
            {
                var model = ParseOclModelContext(m);
                var target = new TargetModel() { Model = model, Parent = _root, Version = _context };
                Model.Add(target);
            }

            return base.VisitTargetModelPattern(context);
        }

        public override bool VisitLibraryRef(ATLParser.LibraryRefContext context)
        {
            var reference = new LibraryRef() { Name = context.STRING().GetText(), Parent = _root, Version = _context };
            Model.Add(reference);
            return base.VisitLibraryRef(context);
        }

        public override bool VisitMatchedRule_abstractContents(ATLParser.MatchedRule_abstractContentsContext context)
        {
            var name = context.IDENTIFIER(0).GetText();

            var rule = new Rule() { Name = name, Lazy = false, Parent = _root, Version = _context };

            Model.Add(rule);
            References.Add(context.SourceInterval.ToString(), rule);

            return base.VisitMatchedRule_abstractContents(context);
        }

        public override bool VisitLazyMatchedRule(ATLParser.LazyMatchedRuleContext context)
        {
            var name = context.IDENTIFIER(0).GetText();

            var rule = new Rule() { Name = name, Lazy = true, Parent = _root, Version = _context };

            Model.Add(rule);
            References.Add(context.SourceInterval.ToString(), rule);

            return base.VisitLazyMatchedRule(context);
        }

        public override bool VisitInPattern(ATLParser.InPatternContext context)
        {
            var parent = GetParentObject(context);

            foreach (var p in context.inPatternElement())
            {
                var model = new InModel { Name = p.simpleInPatternElement().IDENTIFIER(0).GetText(), Parent = parent, Version = _context };

                if (p.simpleInPatternElement().oclType().oclModelElement() != null)
                {
                    var modelElement = p.simpleInPatternElement().oclType().oclModelElement();
                    model.Element = ParseOclModelElementContext(modelElement);
                }
                // Besides parsing the ModelElement, we should also parse the orther types of elements that could be a oclType.

                Model.Add(model);
            }
            return base.VisitInPattern(context);
        }

        public override bool VisitOutPattern(ATLParser.OutPatternContext context)
        {
            var parent = References[context.parent.SourceInterval.ToString()];
            foreach (var p in context.outPatternElement())
            {
                if (p.simpleOutPatternElement() != null)
                {
                    var model = new OutModel
                    {
                        Name = p.simpleOutPatternElement().IDENTIFIER(0).GetText(),
                        Parent = parent,
                        Version = _context
                    };

                    if (p.simpleOutPatternElement().oclType().oclModelElement() != null)
                    {
                        var modelElement = p.simpleOutPatternElement().oclType().oclModelElement();
                        model.Element = ParseOclModelElementContext(modelElement);
                    }
                    // Besides parsing the ModelElement, we should also parse the orther types of elements that could be a oclType.

                    Model.Add(model);
                }
            }
            return base.VisitOutPattern(context);
        }

        public override bool VisitHelper(ATLParser.HelperContext context)
        {
            if (context.oclFeatureDefinition().oclContextDefinition() != null)
            {
                var helper = new Helper() { Parent = _root, Version = _context };

                if (context.oclFeatureDefinition().oclContextDefinition().oclType().oclModelElement() != null)
                {
                    var modelElement = context.oclFeatureDefinition().oclContextDefinition().oclType().oclModelElement();
                    helper.Context = ParseOclModelElementContext(modelElement);
                }

                if (context.oclFeatureDefinition().oclFeature().attribute() != null)
                {
                    var attribute = context.oclFeatureDefinition().oclFeature().attribute();
                    string name = attribute.IDENTIFIER().GetText();
                    helper.Name = name;
                }
                else if (context.oclFeatureDefinition().oclFeature().operation() != null)
                {
                    var operation = context.oclFeatureDefinition().oclFeature().operation();
                    string name = operation.IDENTIFIER().GetText();
                    helper.Name = name;
                }

                Model.Add(helper);
            }

            return base.VisitHelper(context);
        }

        #region Private Helpers

        private object GetParentObject(Antlr4.Runtime.ParserRuleContext context)
        {
            if (context.parent != null)
            {
                string id = context.parent.SourceInterval.ToString();
                return References[id];
            }

            return null;
        }

        private static Model ParseOclModelContext(ATLParser.OclModelContext context)
        {
            var name = (context.IDENTIFIER(0) != null) ? context.IDENTIFIER(0).GetText() : "";
            var metamodel = (context.IDENTIFIER(1) != null) ? context.IDENTIFIER(1).GetText() : "";

            var model = new Model() { Name = name, MetaModel = metamodel };

            return model;
        }

        private static ModelElement ParseOclModelElementContext(ATLParser.OclModelElementContext context)
        {
            var metamodelName = (context.IDENTIFIER(0) != null) ? context.IDENTIFIER(0).GetText() : "";

            string elementName;
            if (context.IDENTIFIER(1) != null)
            {
                elementName = context.IDENTIFIER(1).GetText();
            }
            else if (context.STRING() != null)
            {
                elementName = context.STRING().GetText();
            }
            else
            {
                elementName = "";
            }

            var element = new ModelElement()
            {
                MetaModel = metamodelName,
                Element = elementName
            };

            return element;
        }

        #endregion

    }
}
