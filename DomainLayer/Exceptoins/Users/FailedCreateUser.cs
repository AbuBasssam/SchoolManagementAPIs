namespace DomainLayer.Exceptoins.Users
{
    public class FailedCreateUser : BadRequestException
    {
        public FailedCreateUser(string message) : base(message) { }

    }
    public class UserNotExistsException : BadRequestException
    {
        public UserNotExistsException(string UserName) : base($"User : {UserName} not exists") { }

    }
}
