
namespace Extension.UnitTest.Json;

public class JsonTests
{
    [Theory]
    [InlineData(null)]
    public void FromJson_WithNullOrEmptyJson_ShouldThrowArgumentNullException(string? json)
    {
        Assert.Throws<ArgumentNullException>(json.FromJson<object>);
    }

    [Theory]
    [InlineData("{}")]
    [InlineData("{\"name\":\"John\",\"age\":30}")]
    public void FromJson_WithValidJson_ShouldDeserializeToObject(string json)
    {
        var result = json.FromJson<JsonMockData>();
        Assert.NotNull(result);
    }

#pragma warning disable CS8600
    [Fact]
    public void ToJson_WithNullObject_ShouldReturnNull()
    {
        var json = ((object)null).ToJson();
        Assert.Equal("null", json);
    }
#pragma warning restore CS8600

    [Fact]
    public void ToJson_WithNonNullObject_ShouldSerializeObjectToJson()
    {
        var obj = new JsonMockData() { Name = "John", Age = 30 };
        var json = obj.ToJson();
        Assert.NotNull(json);
    }
}
