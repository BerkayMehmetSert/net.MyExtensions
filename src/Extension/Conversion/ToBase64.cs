namespace Extension.Conversion;

public static partial class ConvertibleExtensions
{
    /// <summary>
    /// Encodes the given string to Base64 representation.
    /// </summary>
    /// <param name="value">String value to be encoded.</param>
    /// <returns>The Base64 representation of the input string.</returns>
    public static string ToBase64(this string? value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var data = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(data);
    }
}
