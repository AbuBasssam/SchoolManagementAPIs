namespace DomainLayer.Exceptoins.Class
{
    public class DuplicateClassNameException : BadRequestException
    {
        public DuplicateClassNameException( string ClassName): base($"This Class Name already exists.") { }
    }


    //: Thrown if a new class schedule conflicts with an existing schedule for the room.


}
