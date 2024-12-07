namespace DomainLayer.Exceptoins.Course
{
    public class CourseStatusException : Exception
    {
        public CourseStatusException(string CourseCode) : base($"This Course is not available .")
        {
        }
    }



    //InvalidCourseDurationException: Raised if the course duration is outside allowed bounds.
    //    PrerequisiteNotMetException: Ensures students meet prerequisites for enrolling.
    //CourseStatusException: Thrown if a student tries to register for a course that’s not available (e.g., archived or completed).
}
