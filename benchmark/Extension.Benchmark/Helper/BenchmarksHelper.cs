namespace Extension.Benchmark.Helper;

public static class BenchmarksHelper
{
    private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

    public const string JsonData = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";
    public const string Base64String = "VGhpcyBpcyBhbiBlbmNvZGVkIHN0cmluZyBvZiBCYXNlNjQgZW5jb2RlZCBzdHJpbmc=";
    public const string OriginalString = "This is a test string for Base64 encoding.";
    public const int IterationCount = 10;
    public const int PartitionSize = 10;
    public static T GetNextValue<T>()
    {
        var size = Unsafe.SizeOf<T>();
        var buffer = new byte[size];
        RandomNumberGenerator.GetBytes(buffer);
        return Unsafe.ReadUnaligned<T>(ref buffer[0]);
    }

    public static string GetNextString(int? length = 10) => Guid.NewGuid().ToString()[..(length ?? 10)];

    public static string GenerateLongBase64String()
    {
        const string shortBase64String = "VGhpcyBpcyBhbiBlbmNvZGVkIHN0cmluZyBvZiBCYXNlNjQgZW5jb2RlZCBzdHJpbmc=";
        var arr = new string[1000];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = shortBase64String;
        }
        return string.Concat(arr);
    }

    public static string GenerateLongString()
    {
        const string shortString = "This is a test string for Base64 encoding.";
        var arr = new string[1000];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = shortString;
        }
        return string.Concat(arr);
    }

    public static List<int> GetRandomIntegersInRange(int minValue, int maxValue, int count)
    {
        if (minValue >= maxValue)
            throw new ArgumentException("minValue must be less than maxValue");
        if (count < 0)
            throw new ArgumentException("count must be non-negative");

        var result = new List<int>(count);
        for (var i = 0; i < count; i++)
        {
            result.Add(GetNextIntValue(minValue, maxValue));
        }
        return result;
    }

    private static int GetNextIntValue(int minValue, int maxValue)
    {
        if (minValue >= maxValue)
            throw new ArgumentException("minValue must be less than maxValue");

        return (GetNextValue<int>() % (maxValue - minValue)) + minValue;
    }
}
