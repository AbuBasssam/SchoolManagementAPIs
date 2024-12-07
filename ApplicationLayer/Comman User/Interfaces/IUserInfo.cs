namespace ApplicationLayer.Features.Students.Helper
{
    public interface IUserInfo
    {
        #region var/prop(s)

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        #endregion

    }


}
