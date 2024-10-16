using System;
using System.Collections.Generic;
using Jint;

namespace LSL.Evaluation.Core.Tests.TestFactories;

public class JintSettings
{
    internal List<Action<Options>> OptionsConfigurators = new();
    internal List<Action<Engine>> EngineConfigurators = new();

    public JintSettings ConfigureOptions(Action<Options> configurator)
    {
        OptionsConfigurators.Add(configurator);
        return this;
    }

    public JintSettings ConfigureEngine(Action<Engine> configurator)
    {
        EngineConfigurators.Add(configurator);
        return this;
    }
}