namespace DomainLayer.Exceptoins.Users
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message) { }
    }
}
