namespace DomainLayer.Exceptoins.Class
{

    public class ClassNotExistsException : BadRequestException
    {
        public ClassNotExistsException(string ClassName) : base($"Class with Name {ClassName}is not exists !") { }

        public ClassNotExistsException(int ClassID) : base($"Class with ID {ClassID}is not exists !") { }

    }





}
