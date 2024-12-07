using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum enComparisonType
    {
        Equal = 1,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual
    }
}