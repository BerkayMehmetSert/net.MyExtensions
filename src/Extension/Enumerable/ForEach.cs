namespace Extension.Enumerable;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Executes a specified action on each element of the IEnumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IEnumerable.
    /// </typeparam>
    /// <param name="source">The IEnumerable to iterate over.
    /// </param>
    /// <param name="action">The Action delegate to execute on each element of the IEnumerable.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when source or action is null.</exception>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(action);

        foreach (var item in source)
        {
            action(item);
        }
    }

    /// <summary>
    /// Executes a specified function on each element of the IEnumerable and discards the result.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IEnumerable.
    /// </typeparam>
    /// <typeparam name="TResult">The type of the result produced by the function.</typeparam>
    /// <param name="source">The IEnumerable to iterate over.
    /// </param>
    /// <param name="action">The Func delegate to execute on each element of the IEnumerable.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when source or action is null.</exception>
    public static void ForEach<T, TResult>(this IEnumerable<T> source, Func<T, TResult> action)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(action);

        foreach (var item in source)
        {
            action(item);
        }
    }
}
