namespace Extension.UnitTest.Conversion;

public class ConversionTests
{
    [Theory]
    [InlineData(5, typeof(int), "5")]
    [InlineData(5.5, typeof(double), "5.5")]
    public void ConvertTo_WithCultureInfo_ShouldConvertSuccessfully<TIn, T>(TIn value, Type targetType, string stringValue)
        where TIn : struct, IConvertible
    {
        var convertedValue = value.ConvertTo<TIn, T>(CultureInfo.InvariantCulture);
        Assert.Equal(Convert.ChangeType(stringValue, targetType, CultureInfo.InvariantCulture), convertedValue);
    }

    [Theory]
    [InlineData(5, "5")]
    [InlineData(5.5, "5.5")]
    public void ConvertTo_WithProvider_ShouldConvertSuccessfully<TIn, T>(TIn value, string stringValue)
        where TIn : struct, IConvertible
    {
        var convertedValue = value.ConvertTo<TIn, T>(CultureInfo.InvariantCulture);
        Assert.NotNull(convertedValue);
        Assert.Equal(stringValue, convertedValue.ToString());
    }

    [Fact]
    public void FromBase64_WithNullValue_ShouldThrowArgumentNullException()
    {
        string? value = null;
        Assert.Throws<ArgumentNullException>(() => value.FromBase64());
    }

    [Theory]
    [InlineData("VGhpcyBpcyBhIHRlc3Q=")]
    [InlineData("aGVsbG8gd29ybGQ=")]
    [InlineData("dGVzdCB3aXRoIHlvdXIgYmFzZSBiZWxvbmc=")]
    public void FromBase64_WithValidBase64String_ShouldDecodeSuccessfully(string base64String)
    {
        var decodedString = base64String.FromBase64();

        Assert.NotNull(decodedString);
        Assert.NotEmpty(decodedString);
        Assert.DoesNotContain("=", decodedString, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("Hello, World!", "SGVsbG8sIFdvcmxkIQ==")]
    [InlineData("", "")]
    public void ToBase64_ShouldEncodeStringToBase64(string value, string expectedBase64)
    {
        var result = value.ToBase64();
        Assert.Equal(expectedBase64, result);
    }

    [Fact]
    public void ToBase64_WithNullValue_ShouldThrowArgumentNullException()
    {
        string? value = null;
        Assert.Throws<ArgumentNullException>(() => value.ToBase64());
    }
}
