namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Removes all the elements from the list that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list from which the elements will be removed.</param>
    /// <param name="match">The predicate that defines the conditions of the elements to remove.</param>
    /// <exception cref="ArgumentNullException">Thrown when list or match is null.</exception>
    public static void RemoveAll<T>(this IList<T>? list, Func<T, bool>? match)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(match);

        for (var i = list.Count - 1; i >= 0; i--)
        {
            if (match(list[i]))
                list.RemoveAt(i);
        }
    }
}
