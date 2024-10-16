using System;

namespace LSL.Evaluation.Core;

/// <summary>
/// EvaluatorExtensions
/// </summary>
public static class EvaluatorExtensions
{
    /// <summary>
    /// Evaluates the given expression and converts the result to a <c><typeparamref name="T"/></c>
    /// </summary>
    /// <param name="source">The original IEvaluator</param>
    /// <param name="expression">The expression to evaluate</param>
    /// <typeparam name="T">The type to return</typeparam>
    /// <returns></returns>
    public static T Evaluate<T>(this IEvaluator source, string expression) => (T)Convert.ChangeType(source.Evaluate(expression), typeof(T));
}
