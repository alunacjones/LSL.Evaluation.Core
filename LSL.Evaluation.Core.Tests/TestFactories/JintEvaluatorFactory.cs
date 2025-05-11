using System;
using System.Collections.Generic;
using System.Linq;
using Jint;

namespace LSL.Evaluation.Core.Tests.TestFactories;

public class JintEvaluatorFactory : IEvaluatorFactory
{
    public IEvaluator Build(Action<IEvaluatorFactoryConfiguration> configurator)
    {
        static void Configure<T>(IEnumerable<Action<T>> configurators, T toConfigure) =>
            configurators.ForEach(i => i.Invoke(toConfigure));

        var config = new EvaluatorFactoryConfiguration();

        configurator.Invoke(config);

        var engine = new Engine();

        Configure(config.CodeToAdd.Select(c => (Action<Engine>)(e => e.Execute(c))), engine);
        Configure(config.ValuesToSet.Select(c => (Action<Engine>)(e => e.SetValue(c.Name, c.Value))), engine);
        
        return new JintEvaluator(engine);
    }

    internal class JintEvaluator : IEvaluator
    {
        private readonly Engine _engine;

        internal JintEvaluator(Engine engine) => _engine = engine;

        public object Evaluate(string expression) => _engine.Evaluate(expression).ToObject();
    }
}
