using System.Text.Json;
using System.Text.Json.Serialization;
using Task1_Backup.Backup.Domain.Entities;

namespace Task1_Backup.Backup.Infrastructure.Serialization
{
    [JsonSourceGenerationOptions(
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters = new[] { typeof(JsonStringEnumConverter) })]
    [JsonSerializable(typeof(Settings))]
    internal partial class JsonContext : JsonSerializerContext
    {
    }
}