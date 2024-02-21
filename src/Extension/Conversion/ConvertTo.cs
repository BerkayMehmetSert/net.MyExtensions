namespace Extension.Conversion;

public static partial class ConvertibleExtensions
{
    /// <summary>
    ///  Convert the value to the specified type
    /// </summary>
    /// <param name="value"> The value to convert </param>
    /// <param name="provider"> An object that supplies culture-specific formatting information </param>
    /// <typeparam name="TIn"> The type of the value to convert </typeparam>
    /// <typeparam name="T"> The type to convert the value to </typeparam>
    /// <returns> The value converted to the specified type </returns>
    public static T ConvertTo<TIn, T>(this TIn value, IFormatProvider provider)
        where TIn : struct, IConvertible
    {
        return (T)Convert.ChangeType(value, typeof(T), provider);
    }

    /// <summary>
    ///  Convert the value to the specified type
    /// </summary>
    /// <param name="value"> The value to convert </param>
    /// <param name="culture"> The culture to use for the conversion </param>
    /// <typeparam name="TIn"> The type of the value to convert </typeparam>
    /// <typeparam name="T"> The type to convert the value to </typeparam>
    /// <returns> The value converted to the specified type </returns>
    public static T ConvertTo<TIn, T>(this TIn value, CultureInfo culture)
        where TIn : struct, IConvertible
    {
        return (T)Convert.ChangeType(value, typeof(T), culture);
    }
}
