using DomainLayer.Enums;

namespace ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses
{
    public class AvailableEnrollmentCoursesDTO
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public enCourseHours CourseHours { get; set; }
        public enLevel CourseLevel { get; set; }

        public AvailableEnrollmentCoursesDTO(string courseCode, string courseName, enCourseHours courseHours, enLevel courseLevel)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            CourseHours = courseHours;
            CourseLevel = courseLevel;
        }
    }
}
