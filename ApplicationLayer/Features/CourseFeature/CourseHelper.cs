using ApplicationLayer.Features.Courses.Queries;
using System.Linq.Expressions;

namespace ApplicationLayer.Features.Courses
{
    public static class CourseHelper
    {
        public static Expression<Func<DomainLayer.Entities.Course, CourseQueryDTO>> CourseDTOMap()
        {

            return
              se => new CourseQueryDTO
              (

                              se.CourseCode,
                              se.CourseName,
                              se.CourseHours,
                              se.CourseLevel,
                              se.HasPractical,
                              se.HasPrerequisite,
                              se.PrerequisiteCourse != null ? se.PrerequisiteCourse.CourseCode : null

              );
        }

        public static string CourseCodeFormat => @"^\d{3}-[A-Z]{3}$";

        public static class CourseValidationMessages
        {
            public static string FormatValidationErrorMessage = "Invalid format ,format must be three upper case letters, a dash, and three numbers (e.g.,123-ABC).";

            public static string CourseLevelValidationErrorMessage = "Course Level must be between " + 1 + " and " + 3;

            public static string CourseHoursErrorValidationMessage = "Course Hours must be between " + 2 + "and" + 4;

        }
    }
}
