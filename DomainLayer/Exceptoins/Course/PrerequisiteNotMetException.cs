namespace DomainLayer.Exceptoins.Course
{
    public class PrerequisiteNotMetException : Exception
    {
        public PrerequisiteNotMetException(int courseId) : base($"Course with ID {courseId} cannot be taken as prerequisites have not been met.") { }
    }


}
