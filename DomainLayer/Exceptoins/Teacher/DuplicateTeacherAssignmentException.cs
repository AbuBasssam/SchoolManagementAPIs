namespace DomainLayer.Exceptoins.Teacher
{
    public class DuplicateTeacherAssignmentException : Exception
    {
        public DuplicateTeacherAssignmentException(int TeacherID) : base($"Tecaher with ID {TeacherID} have multiple time unintentionally.") { }
    }
}
//DuplicateTeacherAssignmentException: Thrown if a teacher is assigned to a course or class multiple times unintentionally.