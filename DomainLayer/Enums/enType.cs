using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum enType
    {
        Theory,
        Practical
    }
}