namespace Extension.UnitTest.Enumerable;

public class EnumerableTests
{
    [Fact]
    public void ForEach_Action_ShouldExecuteActionForEachElement()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        var result = new List<int>();
        list.ForEach(x => result.Add(x * 2));

        Assert.Equal(new List<int>
        {
            2,
            4,
            6,
            8,
            10
        }, result);
    }

    [Fact]
    public void ForEach_Func_ShouldExecuteFunctionForEachElementAndDiscardResult()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        var result = 0;
        list.ForEach(x => result += x);

        Assert.Equal(15, result);
    }

#pragma warning disable CS8604
    [Fact]
    public void ForEach_Action_ShouldThrowArgumentNullExceptionWhenSourceIsNull()
    {
        IEnumerable<int>? source = null;
        Assert.Throws<ArgumentNullException>(() => source.ForEach(Console.WriteLine));
    }
#pragma warning restore CS8604

#pragma warning disable CS8600 CS8625
    [Fact]
    public void ForEach_Func_ShouldThrowArgumentNullExceptionWhenActionIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new List<int>().ForEach((Func<int, string>)null));
    }
#pragma warning restore CS8600 CS8625

    [Fact]
    public void IsAny_ShouldReturnFalse_WhenSourceIsNull()
    {
        IEnumerable<int>? source = null;

        var result = source.IsAny();
        Assert.False(result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void IsAny_ShouldReturnExpectedResult_WhenSourceIsNotNull(bool expectedResult)
    {
        IEnumerable<int> source = expectedResult ? new[] { 1, 2, 3 } : Array.Empty<int>();
        var result = source.IsAny();
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void IsAny_WithPredicate_ShouldReturnExpectedResult_WhenSourceIsNotNull(bool expectedResult)
    {
        IEnumerable<int> source = expectedResult ? new[] { 1, 2, 3 } : Array.Empty<int>();
        var result = source.IsAny(x => x > 0);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void IsAny_WithPredicate_ShouldReturnFalse_WhenSourceIsNull()
    {
        IEnumerable<int>? source = null;
        bool Predicate(int x) => x > 0;

        var result = source.IsAny(Predicate);
        Assert.False(result);
    }
}
