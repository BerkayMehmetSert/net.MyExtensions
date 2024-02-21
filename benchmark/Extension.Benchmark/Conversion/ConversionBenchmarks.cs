namespace Extension.Benchmark.Conversion;

public class ConversionBenchmarks
{
    [Benchmark]
    public void ConvertIntToDoubleWithInvariantCulture()
    {
        var intValue = GetNextValue<int>();
        for (var i = 0; i < IterationCount; i++)
        {
            _ = intValue.ConvertTo<int, double>(CultureInfo.InvariantCulture);
        }
    }

    [Benchmark]
    public void ConvertDoubleToIntWithInvariantCulture()
    {
        var doubleValue = GetNextValue<double>();
        for (var i = 0; i < IterationCount; i++)
        {
            _ = doubleValue.ConvertTo<double, int>(CultureInfo.InvariantCulture);
        }
    }

    [Benchmark]
    public void DecodeBase64String()
    {
        _ = Base64String.FromBase64();
    }

    [Benchmark]
    public void DecodeNullInput()
    {
        string? nullString = null;
        _ = nullString.FromBase64();
    }

    [Benchmark]
    public void DecodeEmptyInput()
    {
        var emptyString = string.Empty;
        _ = emptyString.FromBase64();
    }

    [Benchmark]
    public void DecodeLongBase64String()
    {
        var longBase64String = GenerateLongBase64String();
        _ = longBase64String.FromBase64();
    }

    [Benchmark]
    public void EncodeStringToBase64()
    {
        _ = OriginalString.ToBase64();
    }

    [Benchmark]
    public void EncodeNullInput()
    {
        string? nullString = null;
        _ = nullString.ToBase64();
    }

    [Benchmark]
    public void EncodeEmptyInput()
    {
        var emptyString = string.Empty;
        _ = emptyString.ToBase64();
    }

    [Benchmark]
    public void EncodeLongStringToBase64()
    {
        var longString = GenerateLongString();
        _ = longString.ToBase64();
    }
}
