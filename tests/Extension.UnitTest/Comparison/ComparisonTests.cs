namespace Extension.UnitTest.Comparison;

public class ComparisonTests
{
    [Theory]
    [InlineData(5, 3)]
    [InlineData(-1, -5)]
    public void IsGreaterThan_ShouldReturnTrue_WhenIntValueIsGreaterThanOther(int value, int other)
    {
        var result = value.IsGreaterThan(other);
        Assert.True(result);
    }

    [Theory]
    [InlineData("def", "abc")]
    public void IsGreaterThan_ShouldReturnTrue_WhenStringValueIsGreaterThanOther(string value, string other)
    {
        var result = value.IsGreaterThan(other);
        Assert.True(result);
    }


    [Theory]
    [InlineData(3, 5)]
    [InlineData(-5, -1)]
    public void IsGreaterThan_ShouldReturnFalse_WhenIntValueIsNotGreaterThanOther(int value, int other)
    {
        var result = value.IsGreaterThan(other);
        Assert.False(result);
    }

    [Theory]
    [InlineData("abc", "def")]
    public void IsGreaterThan_ShouldReturnFalse_WhenStringValueIsNotGreaterThanOther(string value, string other)
    {
        var result = value.IsGreaterThan(other);
        Assert.False(result);
    }

    [Theory]
    [InlineData(3, 5)]
    [InlineData(-5, -1)]
    public void IsLessThan_ShouldReturnTrue_WhenIntValueIsLessThanOther(int value, int other)
    {
        var result = value.IsLessThan(other);
        Assert.True(result);
    }

    [Theory]
    [InlineData("abc", "def")]
    public void IsLessThan_ShouldReturnTrue_WhenStringValueIsLessThanOther(string value, string other)
    {
        var result = value.IsLessThan(other);
        Assert.True(result);
    }

    [Theory]
    [InlineData(5, 3)]
    [InlineData(-1, -5)]
    public void IsLessThan_ShouldReturnFalse_WhenIntValueIsNotLessThanOther(int value, int other)
    {
        var result = value.IsLessThan(other);
        Assert.False(result);
    }

    [Theory]
    [InlineData("def", "abc")]
    public void IsLessThan_ShouldReturnFalse_WhenStringValueIsNotLessThanOther(string value, string other)
    {
        var result = value.IsLessThan(other);
        Assert.False(result);
    }
}
