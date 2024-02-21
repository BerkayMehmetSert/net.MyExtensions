namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Partitions the elements of the collection into sub collections of a specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="source">The source collection to partition.</param>
    /// <param name="size">The size of each partition.</param>
    /// <returns>An enumerable of partitions.</returns>
    /// <exception cref="ArgumentNullException">Thrown when source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when size is less than or equal to 0.</exception>
    public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
    {
        var enumerable = source as T[] ?? source.ToArray();
        CheckParameters(enumerable, size);

        var partition = new List<T>(size);
        foreach (var item in enumerable)
        {
            partition.Add(item);
            if (partition.Count != size) continue;

            yield return partition;
            partition = new List<T>(size);
        }

        if (partition.Count is not 0)
            yield return partition;
    }

    private static void CheckParameters<T>(IEnumerable<T> source, int size)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source), "Source collection cannot be null.");

        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Partition size must be greater than 0.");
    }
}
