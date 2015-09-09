using EvolutionService.Engine.Gml.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Engine.Gml
{
    public class BasicGmlVisitor : GMLBaseVisitor<bool>
    {
        public BasicGmlVisitor(string context)
        {
            Model = new List<object>();
            _context = context;
        }

        public List<object> Model { get; set; }
        private readonly string _context;
        private GoalModel _root;

        public override bool VisitRuleGoalModel(GMLParser.RuleGoalModelContext context)
        {
            var name = context.ruleQualifiedName().RULE_ID(0).GetText();

            _root = new GoalModel() { Name = name, Version = _context };

            Model.Add(_root);

            return base.VisitRuleGoalModel(context);
        }

        public override bool VisitRuleImportNamespace(GMLParser.RuleImportNamespaceContext context)
        {
            var name = context.ruleQualifiedNameWithWildcard().GetText();

            var import = new Import() { Namespace = name, Parent = _root, Version = _context };
            Model.Add(import);

            return base.VisitRuleImportNamespace(context);
        }

        public override bool VisitRuleWorkload(GMLParser.RuleWorkloadContext context)
        {
            var name = context.RULE_ID().GetText();
            var content = context.GetText();

            var workload = new Workload() { Name = name, Parent = _root, InnerText = content, Version = _context };
            Model.Add(workload);

            return base.VisitRuleWorkload(context);
        }

        public override bool VisitRuleAppliedQualitativeProperty(GMLParser.RuleAppliedQualitativePropertyContext context)
        {
            var name = context.RULE_ID().GetText();
            var content = context.GetText();

            var property = new QualitativeProperty() { Name = name, Parent = _root, InnerText = content, Version = _context };
            Model.Add(property);

            return base.VisitRuleAppliedQualitativeProperty(context);
        }

        public override bool VisitRuleAppliedQuantitativeProperty(GMLParser.RuleAppliedQuantitativePropertyContext context)
        {
            var name = context.RULE_ID().GetText();
            var content = context.GetText();

            var property = new QuantitativeProperty() { Name = name, Parent = _root, InnerText = content, Version = _context };
            Model.Add(property);

            return base.VisitRuleAppliedQuantitativeProperty(context);
        }

        public override bool VisitRuleHardGoal(GMLParser.RuleHardGoalContext context)
        {
            var name = context.RULE_ID().GetText();
            var content = context.GetText();

            var goal = new HardGoal() { Name = name, Parent = _root, InnerText = content, Version = _context };
            Model.Add(goal);

            return base.VisitRuleHardGoal(context);
        }

        public override bool VisitRuleSoftGoal(GMLParser.RuleSoftGoalContext context)
        {
            var name = context.RULE_ID().GetText();
            var content = context.GetText();

            var goal = new SoftGoal() { Name = name, Parent = _root, InnerText = content, Version = _context };
            Model.Add(goal);

            return base.VisitRuleSoftGoal(context);
        }

        public override bool VisitRuleCompositeGoal(GMLParser.RuleCompositeGoalContext context)
        {
            var name = context.RULE_ID().GetText();
            var content = context.GetText();

            var goal = new SoftGoal() { Name = name, Parent = _root, InnerText = content, Version = _context };
            Model.Add(goal);

            return base.VisitRuleCompositeGoal(context);
        }
    }
}
