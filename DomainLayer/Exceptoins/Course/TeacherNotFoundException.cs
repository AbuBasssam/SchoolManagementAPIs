namespace DomainLayer.Exceptoins.Course
{
    public class TeacherNotFoundException : EntityNotFoundException
    {
        public TeacherNotFoundException(int TeacherId) : base($"The Teacher with the ID {TeacherId} was not found.")
        {
        }
    }
//CourseNotFoundException: If a course ID does not match an existing course.
//DuplicateCourseCodeException: Ensures that course codes are unique.
//CourseCapacityExceededException: Thrown if a student attempts to register for a course that has reached capacity.
//InvalidCourseDurationException: Raised if the course duration is outside allowed bounds.
//    PrerequisiteNotMetException: Ensures students meet prerequisites for enrolling.
//CourseStatusException: Thrown if a student tries to register for a course that’s not available (e.g., archived or completed).
}
