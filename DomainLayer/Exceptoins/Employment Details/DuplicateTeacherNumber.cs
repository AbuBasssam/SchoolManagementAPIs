namespace DomainLayer.Exceptoins.Employment_Details
{
    public class DuplicateTeacherNumber : BadRequestException
    {
        public DuplicateTeacherNumber(string TeacherNumber) : base($"A Teacher with number {TeacherNumber} already Have Details !") { }

    }
}
