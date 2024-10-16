using System;

namespace LSL.Evaluation.Core;

/// <summary>
/// This interface is exposed to consumers of an <c>IEvaluatorFactoryWithSettings&lt;TSettings&gt;</c> in the <c>Build</c> method.
/// </summary>
/// <typeparam name="TSettings"></typeparam>
public interface IEvaluatorFactoryConfigurationWithSettings<TSettings> : IEvaluatorFactoryConfiguration
{
    /// <summary>
    /// Adds an action to configure a <typeparamref name="TSettings"/> instance
    /// </summary>
    /// <param name="settingsConfigurator"></param>    
    void Configure(Action<TSettings> settingsConfigurator);
}