namespace Extension.Conversion;

public static partial class ConvertibleExtensions
{
    /// <summary>
    /// Decodes the given Base64 encoded string and retrieves the original text.
    /// </summary>
    /// <param name="value">Base64 encoded string value.</param>
    /// <returns>The decoded original text of the Base64 encoded string.</returns>
    public static string FromBase64(this string? value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var data = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(data);
    }
}
