using BsonSerDesSampleCSharp;

using var tokenSource = new CancellationTokenSource();

var bob = new Person("Bob", 20, "bob@email.com");
var bsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "bob.bson");

await BsonUtility.SerializeAndWriteFileAsync(bsonFilePath, bob, tokenSource.Token);

var readFromFile = await BsonUtility.LoadFromFile<Person>(bsonFilePath, tokenSource.Token);

Console.WriteLine($"Bob: {readFromFile}");

Console.WriteLine("Completed!");