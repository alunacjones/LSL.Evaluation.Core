using System;

namespace LSL.Evaluation.Core;

/// <summary>
/// Custom factories for evaluators that have settings should derive from this interface
/// </summary>
/// <typeparam name="TSettings"></typeparam>
public interface IEvaluatorFactoryWithSettings<TSettings>
{
    /// <summary>
    /// Builds an evaluator that allows for customisation of settings
    /// </summary>
    /// <param name="configurator">Action that configures the resultant <c>IEvaluator</c></param>
    /// <returns></returns>    
    IEvaluator Build(Action<IEvaluatorFactoryConfigurationWithSettings<TSettings>> configurator);
}