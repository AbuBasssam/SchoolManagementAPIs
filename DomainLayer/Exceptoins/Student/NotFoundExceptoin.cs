namespace DomainLayer.Exceptoins.Student
{
    public class NotFoundExceptoin : EntityNotFoundException
    {
        public NotFoundExceptoin(int StudentID) : base($"Student with ID {StudentID} not found.") { }

    }
    public class DuplicateNationalNoException : BadRequestException
    {
        public DuplicateNationalNoException(string NationalNo) : base($"NationalNO {NationalNo} is already exists") { }

    }
    public class StudentExistsException : BadRequestException
    {
        public StudentExistsException(string StudentNumber) : base($"Student with number {StudentNumber} not exists") { }

    }
    public class UserExistsException : BadRequestException
    {
        public UserExistsException(string UserName) : base($"User with Name {UserName} not exists") { }

    }





}
