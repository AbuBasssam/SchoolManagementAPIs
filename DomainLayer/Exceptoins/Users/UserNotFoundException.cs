namespace DomainLayer.Exceptoins.Users
{
    public static partial class UserException
    {
        public class UserNotFoundException : EntityNotFoundException
        {
            public UserNotFoundException(int UsuerId) : base($"The Usuer with the ID {UsuerId} was not found.")
            {
            }
        }
    }

}
