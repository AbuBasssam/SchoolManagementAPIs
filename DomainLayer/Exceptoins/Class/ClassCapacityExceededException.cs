namespace DomainLayer.Exceptoins.Class
{
    public class ClassCapacityExceededException : BadRequestException
    {
        public ClassCapacityExceededException(string ClassName) : base($"Class with name {ClassName} has reached its maximum capacity.") { }
        public ClassCapacityExceededException(int ClassID) : base($"Class with ID {ClassID} has reached its maximum capacity.") { }

    }




}
