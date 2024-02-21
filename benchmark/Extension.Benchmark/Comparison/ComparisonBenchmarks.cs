namespace Extension.Benchmark.Comparison;

public class ComparisonBenchmarks
{
    [Benchmark]
    public void CompareIntegersForGreaterThan()
    {
        var value1 = GetNextValue<int>();
        var value2 = GetNextValue<int>();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = value1.IsGreaterThan(value2);
        }
    }

    [Benchmark]
    public void CompareDoublesForGreaterThan()
    {
        var value1 = GetNextValue<double>();
        var value2 = GetNextValue<double>();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = value1.IsGreaterThan(value2);
        }
    }

    [Benchmark]
    public void CompareStringsForGreaterThan()
    {
        var value1 = GetNextString();
        var value2 = GetNextString();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = value1.IsGreaterThan(value2);
        }
    }

    [Benchmark]
    public void CompareIntegersForLessThan()
    {
        var value1 = GetNextValue<int>();
        var value2 = GetNextValue<int>();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = value1.IsLessThan(value2);
        }
    }

    [Benchmark]
    public void CompareDoublesForLessThan()
    {
        var value1 = GetNextValue<double>();
        var value2 = GetNextValue<double>();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = value1.IsLessThan(value2);
        }
    }

    [Benchmark]
    public void CompareStringsForLessThan()
    {
        var value1 = GetNextString();
        var value2 = GetNextString();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = value1.IsLessThan(value2);
        }
    }
}
