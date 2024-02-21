namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Removes the first element from the collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection from which the first element will be removed.</param>
    /// <exception cref="ArgumentNullException">Thrown when collection is null.</exception>
    public static void RemoveFirst<T>(this IEnumerable<T>? collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        if (collection is IList<T> { Count: > 0 } list)
            list.Remove(list[0]);
    }

    /// <summary>
    /// Removes a specified number of elements from the beginning of the collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection from which the elements will be removed.</param>
    /// <param name="count">The number of elements to remove.</param>
    /// <exception cref="ArgumentNullException">Thrown when collection is null.</exception>
    public static void RemoveFirst<T>(this IEnumerable<T>? collection, int count)
    {
        ArgumentNullException.ThrowIfNull(collection);

        var list = collection.ToList();
        var itemsToRemove = Math.Min(count, list.Count);
        list.RemoveRange(0, itemsToRemove);
    }

    /// <summary>
    /// Removes the first element from the collection that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection from which the element will be removed.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <exception cref="ArgumentNullException">Thrown when collection or predicate is null.</exception>
    public static void RemoveFirst<T>(this IEnumerable<T>? collection, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(predicate);

        var itemToRemove = collection.FirstOrDefault(predicate);
        if (itemToRemove != null && collection is IList<T> list)
            list.Remove(itemToRemove);
    }

    /// <summary>
    /// Removes a specified number of elements from the beginning of the collection that satisfy a specified condition.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection from which the elements will be removed.</param>
    /// <param name="count">The number of elements to remove.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <exception cref="ArgumentNullException">Thrown when collection or predicate is null.</exception>
    public static void RemoveFirst<T>(this IEnumerable<T>? collection, int count, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(predicate);

        var list = collection.ToList();
        var itemsToRemove = Math.Min(count, list.Count);
        for (var i = 0; i < list.Count; i++)
        {
            if (!predicate(list[i])) continue;

            list.RemoveAt(i);
            itemsToRemove--;
            if (itemsToRemove == 0) break;
        }
    }
}
