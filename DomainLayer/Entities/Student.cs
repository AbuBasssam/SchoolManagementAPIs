using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Student : IEntity
    {
        #region Fileds
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public enLevel GradeLevel { get; set; }
        public int UserID { get; set; }
        public User UserInfo { get; set; } = null!;
        public virtual ICollection<MedicalInformation> MedicalInformationList { get; set; } = null!;
        public virtual ICollection<Section> Sections { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; } = null!;

        #endregion



    }
}
