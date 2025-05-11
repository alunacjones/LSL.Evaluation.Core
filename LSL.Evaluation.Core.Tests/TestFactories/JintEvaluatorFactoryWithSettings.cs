using System;
using System.Collections.Generic;
using System.Linq;
using Jint;
using static LSL.Evaluation.Core.Tests.TestFactories.JintEvaluatorFactory;

namespace LSL.Evaluation.Core.Tests.TestFactories;

public class JintEvaluatorFactoryWithSettings : IEvaluatorFactoryWithSettings<JintSettings>
{
    public IEvaluator Build(Action<IEvaluatorFactoryConfigurationWithSettings<JintSettings>> configurator)
    {
        static void Configure<T>(IEnumerable<Action<T>> configurators, T toConfigure) => 
            configurators.ForEach(i => i.Invoke(toConfigure));

        var config = new EvaluatorFactoryConfigurationWithSettings<JintSettings>();
        var jintSettings = new JintSettings();
        var options = new Options();

        configurator.Invoke(config);

        Configure(config.SettingsConfigurators, jintSettings);
        Configure(jintSettings.OptionsConfigurators, options);

        var engine = new Engine(options);

        Configure(jintSettings.EngineConfigurators, engine);
        Configure(config.CodeToAdd.Select(c => (Action<Engine>)(e => e.Execute(c))), engine);
        Configure(config.ValuesToSet.Select(c => (Action<Engine>)(e => e.SetValue(c.Name, c.Value))), engine);
        
        return new JintEvaluator(engine);
    }
}