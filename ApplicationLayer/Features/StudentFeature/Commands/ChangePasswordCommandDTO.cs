namespace ApplicationLayer.Features.Students.Commands
{
    public class ChangePasswordCommandDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string UserName { get; set; }

        public ChangePasswordCommandDTO(string userName, string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
            UserName = userName;
        }
    }
}