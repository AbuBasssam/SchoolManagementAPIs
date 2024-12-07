namespace DomainLayer.Exceptoins.Users
{
    public class PasswordComplexity : Exception
    {
        public PasswordComplexity() : base($"Password must be more than 8 characters and less than 16, contain at least  1 Captial Letter ,1 Small Letter ,1 character .")
        {
        }
    }

    //PasswordComplexityException: Enforced if passwords do not meet complexity requirements (e.g., length, characters).
    //InactiveUserException: Raised if a user tries to log in or perform actions but is marked as inactive.
}
