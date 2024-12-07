using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum enSemesterType
    {
        TermOne = 1,
        TermTwo = 2,
        Summer = 3
    }
}
