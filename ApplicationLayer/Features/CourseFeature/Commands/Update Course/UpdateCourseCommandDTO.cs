using DomainLayer.Enums;

namespace ApplicationLayer.Features.Courses
{
    public class UpdateCourseCommandDTO
    {

        #region Fields
        public enCourseHours CourseHours { get; set; }
        public enLevel CourseLevel { get; set; }
        public bool HasPractical { get; set; }

        #endregion

        #region Constructure(s)
        public UpdateCourseCommandDTO(enCourseHours courseHours, enLevel courseLevel, bool hasPractical)
        {
            CourseHours = courseHours;
            CourseLevel = courseLevel;
            HasPractical = hasPractical;
        }
        #endregion

    }
}