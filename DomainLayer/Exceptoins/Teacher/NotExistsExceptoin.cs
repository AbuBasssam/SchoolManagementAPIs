namespace DomainLayer.Exceptoins.Teacher
{
    public class TeacherNotExistsExceptoin : BadRequestException
    {
        public TeacherNotExistsExceptoin(string TeacherNumber) : base($"Tecaher with number {TeacherNumber} not exists.") { }
    }
}
