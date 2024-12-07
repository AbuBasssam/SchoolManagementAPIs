using DomainLayer.Contracts;

namespace DomainLayer.Entities
{
    public class Teacher : IEntity
    {
        #region var/prop
        public int Id { get; set; }
        public string SubjectExpertise { get; set; } = null!;
        public string bio { get; set; } = null!;
        public int UserID { get; set; }
        public User UserInfo { get; set; } = null!;
        public EmploymentDetail EmploymentDetails { get; set; } = null!;
        public ICollection<Section> Sections { get; set; } = null!;
        #endregion

    }
}
