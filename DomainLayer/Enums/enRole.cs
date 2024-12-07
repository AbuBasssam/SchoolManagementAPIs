using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum enRole
    {

        Teacher = 1,
        Student,
        Admin,

    }

}