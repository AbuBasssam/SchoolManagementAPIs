namespace DomainLayer.Exceptoins.Teacher
{
    public class InactiveTeacherException : Exception
    {
        public InactiveTeacherException(int TeacherID) : base($"Tecaher with ID {TeacherID} is not active.") { }
    }
}
