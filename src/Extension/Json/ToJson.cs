using System.Text.Json;

namespace Extension.Json;

public static partial class JsonExtensions
{
    /// <summary>
    /// Serializes the object to a JSON string.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <returns>The JSON representation of the object.</returns>
    public static string ToJson<T>(this T? obj) => JsonSerializer.Serialize(obj);
}
