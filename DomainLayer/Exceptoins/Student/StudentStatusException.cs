namespace DomainLayer.Exceptoins.Student
{
    public class StudentStatusException : Exception
    {
        public StudentStatusException(int StudentID) : base($"Student with ID {StudentID}is not active .") { }

    }




}
