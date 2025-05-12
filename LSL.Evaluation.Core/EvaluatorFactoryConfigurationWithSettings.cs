using System;
using System.Collections.Generic;

namespace LSL.Evaluation.Core;

/// <summary>
/// EvaluatorFactoryConfigurationWithSettings&lt;TSettings&gt;
/// </summary>
/// <typeparam name="TSettings"></typeparam>
public class EvaluatorFactoryConfigurationWithSettings<TSettings> : EvaluatorFactoryConfiguration, IEvaluatorFactoryConfigurationWithSettings<TSettings>
{
    private readonly List<Action<TSettings>> _settingsConfigurators = new();

    /// <summary>
    /// A list of actions to execute against a TSettings instance
    /// </summary>
    /// <remarks>This is for use within an implemented factory</remarks>
    public IEnumerable<Action<TSettings>> SettingsConfigurators => _settingsConfigurators;

    /// <inheritdoc/>
    public void Configure(Action<TSettings> settingsConfigurator) => _settingsConfigurators.Add(settingsConfigurator);
}