using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum enChangeType
    {
        Created = 1,
        TimeUpdated,
        ScheduleDaysUpdated,
        Deactivated

    }


}
