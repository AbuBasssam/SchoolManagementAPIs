namespace ApplicationLayer.Features.Students.Helper
{
    public class UserInfoDTOValidator : BaseUserInfoValidator<UserInfoDTO>
    {
        #region Fields
        // private readonly IPersonExistsService _service;

        #endregion

        #region Constructor(s)
        /*public UserInfoDTOValidator(IPersonExistsService service) : base()
        {
            _service = service;

            // ApplyAddValidationrules();

        }*/
        public UserInfoDTOValidator() : base()
        {
            // _service = service;

            // ApplyAddValidationrules();

        }

        #endregion

        #region Actions
        public void ApplyAddValidationrules()
        {


        }

        #endregion





    }
}
