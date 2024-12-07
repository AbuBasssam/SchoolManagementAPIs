namespace DomainLayer.Exceptoins.Section
{
    public class SectionNotExistsException : BadRequestException
    {
        public SectionNotExistsException(string SectionNumber) : base($"Section with number {SectionNumber} is not exists !") { }
    }




}
