namespace DomainLayer.Exceptoins.Course
{
    public class DuplicateCourseNameException : BadRequestException
    {
        public DuplicateCourseNameException(string courseName) : base($"A course with name {courseName} already exists!") { }
    }
}
