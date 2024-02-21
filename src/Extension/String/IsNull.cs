namespace Extension.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Checks if the specified value is null.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is null, otherwise false.</returns>
    public static bool IsNull<T>(this T? value) => value is null;
}
