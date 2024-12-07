using DomainLayer.Enums;

namespace ApplicationLayer.Features.Classes.Queries
{
    public class ClassQueryDTO
    {

        #region Field(s)
        public string ClassName { get; set; }
        private enType ClassType { get; set; }
        public byte ClassCapacity { get; set; }
        public string Type => ClassType.ToString();

        #endregion

        #region Constructure(s)
        public ClassQueryDTO(string className, enType classType, byte classCapacity)
        {
            ClassName = className;
            ClassType = classType;
            ClassCapacity = classCapacity;
        }

        #endregion

    }

}
