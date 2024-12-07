namespace DomainLayer.Exceptoins.Course
{
    public class CourseNotFoundException : EntityNotFoundException
    {
        public CourseNotFoundException(int CourseId) : base($"The Course with the ID {CourseId} was not found.")
        {
        }
        public CourseNotFoundException(string CourseCode) : base($"The Course with code {CourseCode} was not found.")
        {
        }
    }
}





