namespace Extension.Enumerable;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Determines whether any element exists in the specified enumerable.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the enumerable.</typeparam>
    /// <param name="source">The enumerable to check.</param>
    /// <returns>True if the enumerable is not null and contains at least one element; otherwise, false.</returns>
    public static bool IsAny<TSource>(this IEnumerable<TSource>? source) => source is not null && source.Any();

    /// <summary>
    /// Determines whether any element in the specified enumerable satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the enumerable.</typeparam>
    /// <param name="source">The enumerable to check.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>True if the enumerable is not null and contains at least one element that satisfies the condition; otherwise, false.</returns>
    public static bool IsAny<TSource>(this IEnumerable<TSource>? source, Func<TSource, bool> predicate) => source is not null && source.Any(predicate);

}
