using System.Text.Json.Serialization;

namespace DomainLayer.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum enEmploymentDetailOrderingEnum
    {
        ASC = 1,
        DESC = 2,
        HiringDateASC = 3,
        HiringDateDESC = 4,
        ContractType = 5
    }
}