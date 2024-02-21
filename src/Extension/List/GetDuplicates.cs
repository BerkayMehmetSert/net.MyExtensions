namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Retrieves the duplicate elements from the collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection to retrieve duplicates from.</param>
    /// <param name="comparer">The equality comparer to use for comparing elements. If null, the default equality comparer for the type is used.</param>
    /// <param name="capacity">The initial capacity of the hash set used for storing duplicates. If capacity is less than or equal to 0, the default capacity is used.</param>
    /// <returns>An IEnumerable containing the duplicate elements.</returns>
    /// <exception cref="ArgumentNullException">Thrown when collection is null.</exception>
    public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T>? collection,
        IEqualityComparer<T>? comparer = null, int capacity = 0)
    {
        ArgumentNullException.ThrowIfNull(collection);

        var duplicates = new HashSet<T>(capacity, comparer ?? EqualityComparer<T>.Default);
        var uniques = new HashSet<T>(capacity, comparer ?? EqualityComparer<T>.Default);

        foreach (var item in collection)
        {
            if (!uniques.Add(item))
                duplicates.Add(item);
        }

        return duplicates;
    }
}
