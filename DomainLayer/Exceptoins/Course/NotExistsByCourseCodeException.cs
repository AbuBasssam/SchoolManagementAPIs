namespace DomainLayer.Exceptoins.Course
{
    public class NotExistsByCourseCodeException : BadRequestException
    {
        public NotExistsByCourseCodeException(string courseCode)
            : base($"A course with code {courseCode} not exists!") { }
    }

}
