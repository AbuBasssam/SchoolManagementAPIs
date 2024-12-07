namespace DomainLayer.Exceptoins.Course
{
    public class PrerequisiteNotExistsException : BadRequestException
    {
        public PrerequisiteNotExistsException(string courseCode) : base($"Course with code {courseCode} not exists.") { }
    }


}
