namespace LSL.Evaluation.Core;

/// <summary>
/// IEvaluator
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Evaluates the given expresion
    /// </summary>
    /// <param name="expression"></param>
    /// <returns>The result of the evaluation</returns>
    object Evaluate(string expression);
}
