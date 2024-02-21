namespace Extension.Comparison;

public static partial class ComparableExtensions
{
    /// <summary>
    /// Check if the value is less than the other
    /// </summary>
    /// <param name="value"> The value to check </param>
    /// <param name="other"> The other value to compare </param>
    /// <typeparam name="T"> IComparable type </typeparam>
    /// <returns> True if the value is less than the other, otherwise false </returns>
    public static bool IsLessThan<T>(this T value, T other) where T : IComparable<T> => value.CompareTo(other) < 0;
}
