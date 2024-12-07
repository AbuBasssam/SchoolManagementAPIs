namespace DomainLayer.Exceptoins.Section
{
    public class DuplicateSectionNumberException : BadRequestException
    {
        public DuplicateSectionNumberException(string SectionNumber) : base($"Section with number {SectionNumber}already exists !"){}
    }




}
