namespace DomainLayer.Exceptoins.Course
{
    public class DuplicateCourseCodeException : BadRequestException
    {
        public DuplicateCourseCodeException(string courseCode)
            : base($"A course with code {courseCode} already exists!") { }
    }

}
