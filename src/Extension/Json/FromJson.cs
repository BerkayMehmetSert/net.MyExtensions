using System.Text.Json;

namespace Extension.Json;

public static partial class JsonExtensions
{
    /// <summary>
    /// Deserializes the JSON string to an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of object to deserialize to.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    /// <exception cref="ArgumentNullException">Thrown when json is null.</exception>
    public static T? FromJson<T>(this string? json)
    {
        ArgumentNullException.ThrowIfNull(json);

        return JsonSerializer.Deserialize<T>(json);
    }
}
