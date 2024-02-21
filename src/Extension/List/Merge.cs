namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Merges the elements of the specified collection into the list at the specified index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list into which the elements will be merged.</param>
    /// <param name="index">The zero-based index at which the elements of the collection will be merged.</param>
    /// <param name="collection">The collection whose elements should be merged into the list.</param>
    /// <exception cref="ArgumentNullException">Thrown when list or collection is null.</exception>
    public static void Merge<T>(this IList<T>? list, int index, IEnumerable<T>? collection)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(collection);

        foreach (var item in collection)
        {
            list.Insert(index++, item);
        }
    }
}
