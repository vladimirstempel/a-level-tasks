using System.Text.Json.Serialization;

namespace ConsoleEFApp.Models;

[JsonSerializable(typeof(List<Pet>))]
internal partial class JsonPetContext : JsonSerializerContext
{
}