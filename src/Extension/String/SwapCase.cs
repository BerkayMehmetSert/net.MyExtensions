namespace Extension.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Swaps the case of each character in the specified string.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <param name="culture">The culture information used for case conversion. If null, CultureInfo.InvariantCulture is used.</param>
    /// <returns>The string with swapped case.</returns>
    /// <exception cref="ArgumentNullException">Thrown when str is null.</exception>
    public static string SwapCase(this string? str, CultureInfo? culture = null)
    {
        ArgumentNullException.ThrowIfNull(str);

        var result = new StringBuilder(str.Length);
        foreach (var c in str)
        {
            result.Append(SwapCharCase(c, culture));
        }

        return result.ToString();
    }

    private static char SwapCharCase(char c, CultureInfo? culture) => char.IsLower(c)
        ? char.ToUpper(c, culture ?? CultureInfo.InvariantCulture)
        : char.ToLower(c, culture ?? CultureInfo.InvariantCulture);
}
