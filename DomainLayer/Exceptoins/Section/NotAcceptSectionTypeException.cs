namespace DomainLayer.Exceptoins.Section
{
    public class NotAcceptSectionTypeException : BadRequestException
    {
        public NotAcceptSectionTypeException(string CourseCode) : base($"Cannot add a Practical section to the course '{CourseCode}' which does not allow practicals") { }
    }
}
