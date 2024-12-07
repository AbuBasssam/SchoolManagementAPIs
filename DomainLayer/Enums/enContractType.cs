using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum enContractType
    {
        PartTime,
        FullTime
    }

}