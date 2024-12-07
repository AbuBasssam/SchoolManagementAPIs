using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Class : IEntity
    {
        #region var/prop
        public int Id { get; set; }
        public string ClassName { get; set; } = null!;
        public enType ClassType { get; set; }
        public byte ClassCapacity { get; set; }
        #endregion

    }
}
