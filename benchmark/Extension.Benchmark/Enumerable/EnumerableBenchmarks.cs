namespace Extension.Benchmark.Enumerable;

public class EnumerableBenchmarks
{
    [Benchmark]
    public void ExecuteActionForEachElement()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.ForEach(x => _ = x);
    }

    [Benchmark]
    public void ExecuteFunctionForEachElement()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.ForEach(x => x);
    }

#pragma warning disable CS8602 S2259
    [Benchmark]
    public void ExecuteActionForEachElementWithNullSource()
    {
        List<int>? list = null;
        list.ForEach(x => _ = x);
    }
#pragma warning restore CS8602 S2259

#pragma warning disable CS8604 S2259
    [Benchmark]
    public void ExecuteFunctionForEachElementWithNullSource()
    {
        List<int>? list = null;
        list.ForEach(x => x);
    }
#pragma warning restore CS8604 S2259

    [Benchmark]
    public void ExecuteActionForEachElementWithNullAction()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.ForEach<int>(null!);
    }

    [Benchmark]
    public void ExecuteIsAny()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        _ = list.IsAny();
    }

    [Benchmark]
    public void ExecuteIsAnyWithNullSource()
    {
        List<int>? list = null;
        _ = list.IsAny();
    }

    [Benchmark]
    public void ExecuteIsAnyWithPredicate()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        _ = list.IsAny(x => x > 3);
    }

    [Benchmark]
    public void ExecuteIsAnyWithPredicateAndNullSource()
    {
        List<int>? list = null;
        _ = list.IsAny(x => x > 3);
    }
}
