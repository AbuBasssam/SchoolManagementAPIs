using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Section : IEntity
    {

        #region Fileds
        public int Id { get; set; }
        public string SectionNumber { get; set; } = null!;
        public enType SectionType { get; set; }
        public int CourseID { get; set; }
        public int? TeacherID { get; set; }
        public int ScheduleID { get; set; }
        public bool IsOpen { get; set; }

        public Schedule Schedule { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public Teacher? Teacher { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; } = null!;
        #endregion

    }



}
