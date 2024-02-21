namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Adds the elements of the specified array to the end of the IList.
    /// </summary>
    /// <typeparam name="T">The type of elements in the IList.</typeparam>
    /// <param name="list">The IList to which the elements will be added.</param>
    /// <param name="collection">The array whose elements should be added to the end of the IList.</param>
    /// <exception cref="ArgumentNullException">Thrown when list or collection is null.</exception>
    public static void AddRange<T>(this IList<T>? list, params T[]? collection)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(collection);

        list.AddRange((IEnumerable<T>)collection);
    }

    /// <summary>
    /// Adds the specified number of elements from the specified collection starting at the specified index to the end of the IList.
    /// </summary>
    /// <typeparam name="T">The type of elements in the IList.</typeparam>
    /// <param name="list">The IList to which the elements will be added.</param>
    /// <param name="collection">The collection whose elements should be added to the end of the IList.</param>
    /// <param name="index">The zero-based index in the collection at which copying begins.</param>
    /// <param name="count">The number of elements to add from the collection.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when index or count is less than 0.</exception>
    /// <exception cref="ArgumentNullException">Thrown when list or collection is null.</exception>
    public static void AddRange<T>(this IList<T>? list, IEnumerable<T>? collection, int index, int count)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(collection);
        if (index < 0 || count < 0)
            throw new ArgumentOutOfRangeException("Index and count must be non-negative.", (Exception?)null);

        list.AddRange(collection.Skip(index).Take(count));
    }

    /// <summary>
    /// Adds the specified number of elements from the beginning of the specified collection to the end of the IList.
    /// </summary>
    /// <typeparam name="T">The type of elements in the IList.</typeparam>
    /// <param name="list">The IList to which the elements will be added.</param>
    /// <param name="collection">The collection whose elements should be added to the end of the IList.</param>
    /// <param name="count">The number of elements to add from the beginning of the collection.</param>
    /// <exception cref="ArgumentNullException">Thrown when list or collection is null.</exception>
    public static void AddRange<T>(this IList<T>? list, IEnumerable<T>? collection, int count)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(collection);

        list.AddRange(collection.Take(count));
    }

    /// <summary>
    /// Adds the elements of the specified collection to the end of the IList.
    /// </summary>
    /// <typeparam name="T">The type of elements in the IList.</typeparam>
    /// <param name="list">The IList to which the elements will be added.</param>
    /// <param name="collection">The collection whose elements should be added to the end of the IList.</param>
    /// <exception cref="ArgumentNullException">Thrown when list or collection is null.</exception>
    private static void AddRange<T>(this IList<T>? list, IEnumerable<T>? collection)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(collection);

        if (list is List<T> concreteList)
        {
            concreteList.AddRange(collection);
        }
        else
        {
            foreach (var item in collection)
            {
                list.Add(item);
            }
        }
    }
}
