namespace DomainLayer.Exceptoins.Course
{
    public class DuplicatePrerequisiteExceptoin:BadRequestException
    {
        public DuplicatePrerequisiteExceptoin(string CourseCode):base($"Course with code {CourseCode} already a prerequisite.") { }
    }


}
