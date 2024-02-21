namespace Extension.List;

public static partial class ListExtensions
{
    /// <summary>
    /// Shuffles the elements of the list in a random order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to be shuffled.</param>
    /// <exception cref="ArgumentNullException">Thrown when list is null.</exception>
    public static void Shuffle<T>(this IList<T>? list)
    {
        ArgumentNullException.ThrowIfNull(list);

        using var provider = RandomNumberGenerator.Create();
        var n = list.Count;
        while (n > 1)
        {
            var box = new byte[1];
            do provider.GetBytes(box);
            while (box[0] >= n * (byte.MaxValue / n));
            var k = box[0] % n;
            n--;
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
