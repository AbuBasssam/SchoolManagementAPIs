namespace DomainLayer.Exceptoins.Users
{
    public class DuplicateUserNameException:Exception 
    {
        public DuplicateUserNameException(int UserName) : base($"This UserName {UserName} Already Exists.")
        {
        }
    }
}
