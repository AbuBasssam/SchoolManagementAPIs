namespace DomainLayer.Exceptoins.Employment_Details
{
    public class NotExistsDetails : BadRequestException
    {
        public NotExistsDetails(string TeacherNumber) : base($"A detail for teacher number {TeacherNumber} not exists !") { }

    }
}
