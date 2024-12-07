namespace DomainLayer.Exceptoins.Student
{
    public class StudentNotExistsException : BadRequestException
    {
        public StudentNotExistsException(string StudentNumber) : base($"Student with number {StudentNumber} not exists") { }

    }

}
