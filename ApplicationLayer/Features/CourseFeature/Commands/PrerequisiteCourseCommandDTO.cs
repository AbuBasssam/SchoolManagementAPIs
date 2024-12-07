namespace ApplicationLayer.Features.Courses.Commands
{
    public class PrerequisiteCourseCommandDTO
    {

        #region Fields
        public string CourseCode { get; set; }
        public string PrerequisiteCourseCode { get; set; }


        #endregion

        #region Constructure(s)
        public PrerequisiteCourseCommandDTO(string courseCode, string newPrerequisiteCourse)
        {
            CourseCode = courseCode;
            PrerequisiteCourseCode = newPrerequisiteCourse;

        }
        #endregion

    }
}