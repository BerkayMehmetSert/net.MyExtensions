namespace Extension.UnitTest.String;

public class StringTests
{
    [Fact]
    public void IsNull_ShouldReturnTrue_WhenValueIsNull()
    {
        string? value = null;
        var result = value.IsNull();
        Assert.True(result);
    }

    [Fact]
    public void IsNull_ShouldReturnFalse_WhenValueIsNotNull()
    {
        const string value = "Hello";
        var result = value.IsNull();
        Assert.False(result);
    }

    [Fact]
    public void IsNull_ShouldReturnFalse_WhenValueIsNotNullableType()
    {
        const int value = 42;
        var result = value.IsNull();
        Assert.False(result);
    }
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", false)]
    [InlineData("hello", false)]
    public void IsNullOrEmpty_ShouldReturnCorrectResult<T>(T? value, bool expectedResult)
    {
        var result = value.IsNullOrEmpty();
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("  ", true)]
    [InlineData("hello", false)]
    public void IsNullOrWhiteSpace_ShouldReturnCorrectResult(string? value, bool expectedResult)
    {
        var result = value.IsNullOrWhiteSpace();
        Assert.Equal(expectedResult, result);
    }
}
