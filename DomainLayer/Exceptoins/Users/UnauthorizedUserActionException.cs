namespace DomainLayer.Exceptoins.Users
{
    public class UnauthorizedUserActionException : Exception
    {
        public UnauthorizedUserActionException() : base($"You are Unauthorized.")
        {
        }
    }

    //PasswordComplexityException: Enforced if passwords do not meet complexity requirements (e.g., length, characters).
    //InactiveUserException: Raised if a user tries to log in or perform actions but is marked as inactive.
}
