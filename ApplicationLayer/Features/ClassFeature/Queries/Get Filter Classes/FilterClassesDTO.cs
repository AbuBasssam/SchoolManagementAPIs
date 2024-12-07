using DomainLayer.Enums;

namespace ApplicationLayer.Features.Classes.Queries.Get_Filter_Classes
{
    public class FilterClassesDTO
    {

        #region Field(s)
        public enType? Type { get; set; }
        public byte? Capacity { get; set; }
        public enComparisonType ComparisonType { get; set; }

        #endregion

        #region Constructure(s)
        public FilterClassesDTO(enType? type, byte? capacity, enComparisonType comparisonType = enComparisonType.Equal)
        {
            Type = type;
            Capacity = capacity;
            ComparisonType = comparisonType;
        }

        #endregion
    }

}
