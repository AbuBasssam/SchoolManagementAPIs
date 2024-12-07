namespace DomainLayer.Exceptoins.Course
{
    public class PrerequisiteNullableExceptoin : BadRequestException
    {
        public PrerequisiteNullableExceptoin(string CourseCode) : base($"Course with code {CourseCode} not have  prerequisites.") { }


    }


}
