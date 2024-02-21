namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Maps the elements of the list using the specified mapping function that takes the index of each element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list whose elements will be mapped.</param>
    /// <param name="map">The mapping function.</param>
    /// <exception cref="ArgumentNullException">Thrown when list or map is null.</exception>
    public static void Map<T>(this IList<T>? list, Func<T, int, T>? map)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(map);

        for (var i = 0; i < list.Count; i++)
            list[i] = map(list[i], i);
    }
}
