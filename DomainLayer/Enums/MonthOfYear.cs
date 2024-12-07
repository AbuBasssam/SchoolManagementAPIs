using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MonthOfYear
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}