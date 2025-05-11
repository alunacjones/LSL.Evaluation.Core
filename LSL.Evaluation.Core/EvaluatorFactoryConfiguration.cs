using System;
using System.Collections.Generic;

namespace LSL.Evaluation.Core;

/// <summary>
/// EvaluatorFactoryConfiguration
/// </summary>
public class EvaluatorFactoryConfiguration : IEvaluatorFactoryConfiguration
{
    /// <summary>
    /// A list of code to execute within the implemented evaluator's scripting engine
    /// </summary>
    /// <remarks>This is for use within an implemented factory</remarks>
    /// <returns></returns>
    public List<string> CodeToAdd = new();

    /// <summary>
    /// A list of values to set within an implemented evaluator's scripting engine
    /// </summary>
    public List<(string Name, object Value)> ValuesToSet = new();

    /// <inheritdoc/>
    public void AddCode(string code) => CodeToAdd.Add(code);

    /// <inheritdoc/>
    public void SetValue(string name, object value) => ValuesToSet.Add((name, value));
}