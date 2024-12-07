using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Course : IEntity
    {
        #region var/ prop
        public int Id { get; set; }
        public string CourseCode { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public enCourseHours CourseHours { get; set; }
        public enLevel CourseLevel { get; set; }
        public bool HasPractical { get; set; }
        public bool HasPrerequisite { get; set; }
        public int? PrerequisiteID { get; set; }
        public Course? PrerequisiteCourse { get; set; }
        public ICollection<Section> CourseSections { get; set; } = null!;
        public ICollection<Assignment> CourseAssignments { get; set; } = null!;

        #endregion

        #region Constructure(s)

        #endregion
    }
}
