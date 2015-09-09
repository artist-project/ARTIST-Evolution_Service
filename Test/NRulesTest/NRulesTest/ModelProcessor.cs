﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NRules;
using NRules.Fluent;

namespace NRulesTest
{
    public class ModelProcessor
    {
        private ISessionFactory factory;

        public ModelProcessor()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Initialize(currentAssembly);
        }

        private void Initialize(Assembly ruleAssembly)
        {
            var repository = new RuleRepository();

            repository.Load(x => x.From(ruleAssembly));
            var ruleSets = repository.GetRuleSets();

            factory = repository.Compile();
        }

        public List<ChangeDefinition> Process(List<object> facts)
        {
            ISession session = factory.CreateSession();

            foreach (var f in facts)
            {
                session.Insert(f);
            }

            session.Fire();

            var derivedFacts = session.Query<ChangeDefinition>().ToList();

            return derivedFacts;
        }
    }
}