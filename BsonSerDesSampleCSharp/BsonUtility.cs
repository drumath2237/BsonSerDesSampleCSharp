using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace BsonSerDesSampleCSharp;

public static class BsonUtility
{
    public static async Task SerializeAndWriteFileAsync<T>(string filePath, T data, CancellationToken token = default)
    {
        await using var stream = new MemoryStream();
        using var bsonDataWriter = new BsonDataWriter(stream);

        var serializer = new JsonSerializer();
        serializer.Serialize(bsonDataWriter, data);

        var bsonData = stream.ToArray();

        await File.WriteAllBytesAsync(filePath, bsonData, token);
    }

    public static async Task<T?> LoadFromFile<T>(string filePath, CancellationToken token = default)
    {
        var bsonData = await File.ReadAllBytesAsync(filePath, token);

        await using var stream = new MemoryStream(bsonData);
        using var bsonDataReader = new BsonDataReader(stream);

        var serializer = new JsonSerializer();
        var sensorData = serializer.Deserialize<T>(bsonDataReader);

        return sensorData;
    }
}