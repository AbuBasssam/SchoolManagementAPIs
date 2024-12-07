namespace DomainLayer.Exceptoins.Users
{
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException() : base($"Your Email is Invalid fromat.")
        {
        }
    }

    //InvalidEmailFormatException: Raised if a provided email doesn’t meet required formatting.
    //DuplicateUserNameException: Ensures unique usernames for all users.
    //UnauthorizedUserActionException: If a user attempts an action without necessary privileges.
    //PasswordComplexityException: Enforced if passwords do not meet complexity requirements (e.g., length, characters).
    //InactiveUserException: Raised if a user tries to log in or perform actions but is marked as inactive.
}
