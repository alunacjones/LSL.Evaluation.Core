using System;
using System.Collections.Generic;

namespace LSL.Evaluation.Core;

/// <summary>
/// EnumerableExtensions
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Performs the given action against each item
    /// </summary>
    /// <param name="items"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (action == null) throw new ArgumentNullException(nameof(action));

        foreach (var item in items)
        {
            action(item);
        }        
    }
}