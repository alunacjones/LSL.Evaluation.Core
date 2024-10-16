using System;

namespace LSL.Evaluation.Core;

/// <summary>
/// Custom factories should derive from this interface
/// </summary>
public interface IEvaluatorFactory
{
    /// <summary>
    /// Builds an evaluator
    /// </summary>
    /// <param name="configurator">Action that configures the resultant <c>IEvaluator</c></param>
    /// <returns></returns>
    IEvaluator Build(Action<IEvaluatorFactoryConfiguration> configurator);
}
