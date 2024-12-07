using DomainLayer.Enums;

namespace ApplicationLayer.Features.Courses.Queries
{
    public class CourseQueryDTO
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public enCourseHours CourseHours { get; set; }
        public enLevel CourseLevel { get; set; }
        public bool HasPractical { get; set; }
        private bool HasPrerequisite { get; set; }
        public string? PrerequisiteCourseCode { get; set; }

        public CourseQueryDTO(string courseCode, string courseName, enCourseHours courseHours,
            enLevel courseLevel, bool hasPractical, bool hasPrerequisite, string? prerequisiteCourseCode = null)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            CourseHours = courseHours;
            CourseLevel = courseLevel;
            HasPractical = hasPractical;
            HasPrerequisite = hasPrerequisite;
            PrerequisiteCourseCode = prerequisiteCourseCode;
        }

    }
}