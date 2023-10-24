using BsonSerDesSampleCSharp;

using var tokenSource = new CancellationTokenSource();

var bob = new Person("Bob", 20, "bob@email.com");
var bsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "bob.bson");

await BsonFileUtility.SerializeAndWriteFileAsync(bsonFilePath, bob, tokenSource.Token);

var person = await BsonFileUtility.LoadFromFileAsync<Person>(bsonFilePath, tokenSource.Token);

Console.WriteLine($"Bob: {person}");