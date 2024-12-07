using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class FilterClasses
    {
        #region  var/prop
        public enType? Type { get; set; }
        public byte? Capacity { get; set; }
        public enComparisonType ComparisonType { get; set; }
        #endregion

        #region Constructure(s)
        public FilterClasses()
        {
            ComparisonType = enComparisonType.Equal;
        }

        #endregion
    }
}
