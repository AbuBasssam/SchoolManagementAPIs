using DomainLayer.Enums;

namespace ApplicationLayer.Features.Courses.Commands
{
    public class AddCourseCommandDTO
    {

        #region Field(s)
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public enCourseHours CourseHours { get; set; }
        public enLevel CourseLevel { get; set; }
        public bool HasPractical { get; set; }
        public string? PrerequisiteCourseCode { get; set; }
        #endregion

        #region Constructure(s)

        public AddCourseCommandDTO(string courseCode, string courseName, enCourseHours courseHours,
            enLevel courseLevel, bool hasPractical, string? prerequisiteCourseCode)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            CourseHours = courseHours;
            CourseLevel = courseLevel;
            HasPractical = hasPractical;
            PrerequisiteCourseCode = prerequisiteCourseCode;
        }

        #endregion

    }

}
