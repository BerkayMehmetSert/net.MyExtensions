namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Applies an accumulator function over the elements of the list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list over which the accumulator function will be applied.</param>
    /// <param name="func">The accumulator function.</param>
    /// <returns>The result of the accumulator function.</returns>
    /// <exception cref="ArgumentNullException">Thrown when list or func is null.</exception>
    public static T Reduce<T>(this IList<T>? list, Func<T, T, T>? func)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(func);

        if (list.Count == 0)
            throw new InvalidOperationException("The list is empty.");

        var result = list[0];
        for (var i = 1; i < list.Count; i++)
            result = func(result, list[i]);
        return result;
    }
}
