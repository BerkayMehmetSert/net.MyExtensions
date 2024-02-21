namespace Extension.Benchmark.Json;

public class JsonBenchmarks
{

    [Benchmark]
    public void DeserializeJson()
    {
        _ = JsonData.FromJson<JsonMockData>();
    }

    [Benchmark]
    public void SerializeJson()
    {
        var obj = new JsonMockData { Name = "John", Age = 30 };
        _ = obj.ToJson();

    }
}
