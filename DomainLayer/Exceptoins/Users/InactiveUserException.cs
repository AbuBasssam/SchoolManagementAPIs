namespace DomainLayer.Exceptoins.Users
{
    public class InactiveUserException : Exception
    {
        public InactiveUserException(string UserName) : base($"This User is inacative.")
        {
        }
    }

    //InactiveUserException: Raised if a user tries to log in or perform actions but is marked as inactive.
}
