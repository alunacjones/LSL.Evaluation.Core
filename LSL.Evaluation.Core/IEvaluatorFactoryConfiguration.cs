namespace LSL.Evaluation.Core;

/// <summary>
/// This interface is exposed to consumers of an <c>IEvaluatorFactory</c> in the <c>Build</c> method.
/// </summary>
public interface IEvaluatorFactoryConfiguration
{
    /// <summary>
    /// Add code to execute within the scripting engine of the implemented evaluator
    /// </summary>
    /// <remarks>Dpending on the underlying scripting engine, this can include function definitions and variable instantiation, etc</remarks>
    /// <param name="code">The code to execute within the evaluator's scripting engine</param>    
    void AddCode(string code);

    /// <summary>
    /// Sets a variable within the scripting engine
    /// </summary>
    /// <remarks>
    /// This can be anything, including functions
    /// </remarks>
    /// <param name="name"></param>
    /// <param name="value"></param>
    void SetValue(string name, object value);
}
