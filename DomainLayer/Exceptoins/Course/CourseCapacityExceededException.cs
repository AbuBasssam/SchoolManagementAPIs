namespace DomainLayer.Exceptoins.Course
{
    public class CourseCapacityExceededException : Exception
    {
        public CourseCapacityExceededException(int courseId)
            : base($"Course with ID {courseId} has exceeded its maximum capacity.") { }
    }
}
