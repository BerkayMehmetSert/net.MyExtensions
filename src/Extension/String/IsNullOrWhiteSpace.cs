namespace Extension.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Checks if the specified value is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is null, empty, or consists only of white-space characters; otherwise, false.</returns>
    public static bool IsNullOrWhiteSpace<T>(this T? value)
    {
        return value switch
        {
            null => true,
            string str => string.IsNullOrWhiteSpace(str),
            _ => false
        };
    }
}
