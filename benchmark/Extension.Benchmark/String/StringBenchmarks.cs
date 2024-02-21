namespace Extension.Benchmark.String;

public class StringBenchmarks
{
    private const string? NullableString = null;
    private const string EmptyString = "";
    private const string WhiteSpaceString = " ";
    private const string NonNullableString = "Hello World";
    private readonly CultureInfo _culture = CultureInfo.InvariantCulture;

    [Benchmark]
    public bool TestIsNull_Nullable() => NullableString.IsNull();

    [Benchmark]
    public bool TestIsNull_NonNullable() => NonNullableString.IsNull();

    [Benchmark]
    public bool TestIsNullOrEmpty_Nullable() => NullableString.IsNullOrEmpty();

    [Benchmark]
    public bool TestIsNullOrEmpty_Empty() => EmptyString.IsNullOrEmpty();

    [Benchmark]
    public bool TestIsNullOrEmpty_NonEmpty() => NonNullableString.IsNullOrEmpty();

    [Benchmark]
    public bool TestIsNullOrWhiteSpace_NonEmpty() => WhiteSpaceString.IsNullOrEmpty();

    [Benchmark]
    public string TestSwapCase() => NonNullableString.SwapCase(_culture);
}
