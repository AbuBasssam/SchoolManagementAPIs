namespace ApplicationLayer.Features.Students.Helper
{
    public class UserInfoDTO : IUserInfo
    {

        #region Field(s)
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        #endregion

        #region Constructure(s)
        public UserInfoDTO(string phoneNumber, string password, string confirmPassword)
        {

            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        #endregion

    }


}
