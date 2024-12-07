using DomainLayer;

namespace DomainLayer.Exceptoins.Teacher
{
    public class NotFoundExceptoin : EntityNotFoundException
    {
        public NotFoundExceptoin(int TeacherID) : base($"Tecaher with ID {TeacherID} not found.") { }
    }
}
//DuplicateTeacherAssignmentException: Thrown if a teacher is assigned to a course or class multiple times unintentionally.
public class TeacherNotExistsException : BadRequestException
{
    public TeacherNotExistsException(string TeacherNumber) : base($"Teacher with number {TeacherNumber} not exists") { }

}