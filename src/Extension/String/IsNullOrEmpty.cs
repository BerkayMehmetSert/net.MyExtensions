namespace Extension.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Checks if the specified value is null or empty.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is null or empty, otherwise false.</returns>
    public static bool IsNullOrEmpty<T>(this T? value)
    {
        return value switch
        {
            null => true,
            string str => string.IsNullOrEmpty(str),
            _ => false
        };
    }
}
