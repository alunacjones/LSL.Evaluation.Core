using System;
using System.Collections.Generic;

namespace LSL.Evaluation.Core;

/// <summary>
/// EvaluatorFactoryConfigurationExtensions
/// </summary>
public static class EvaluatorFactoryConfigurationExtensions
{
    /// <summary>
    /// Set multiple values with the provided key-value pairs
    /// </summary>
    /// <param name="source"></param>
    /// <param name="values"></param>
    public static void SetValues(this IEvaluatorFactoryConfiguration source, IEnumerable<KeyValuePair<string, object>> values)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (values == null) throw new ArgumentNullException(nameof(values));

        foreach (var kvp in values)
        {
            source.SetValue(kvp.Key, kvp.Value);
        }
    }
}