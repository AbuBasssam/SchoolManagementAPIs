using ApplicationLayer.Features.Students.Helper;
using FluentValidation;

namespace ApplicationLayer.Features.UserFeature.Commands.AddAdminCommand
{
    public class AddAdminCommandValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
       // private readonly IStudentService _service;
        private readonly AddInfoDTOValidator _InfoDTOValidator;
        private readonly UserInfoDTOValidator _UserInfoDTOValidator;
        #endregion

        #region Constructor(s)
        public AddAdminCommandValidator()//IStudentService service
        {
           // _service = service;
            _InfoDTOValidator = new AddInfoDTOValidator();
            _UserInfoDTOValidator = new UserInfoDTOValidator();
            ApplyValidations();

        }

        #endregion

        #region Action(s)
        private void ApplyValidations()
        {
            InfoValidation();

            UserInfoValidation();

            EmailValidation();

        }

        private void InfoValidation()
            => RuleFor(x => x.DTO.InfoDTO).SetValidator(_InfoDTOValidator);

        private void UserInfoValidation()
           => RuleFor(x => x.DTO.UserInfoDTO).SetValidator(_UserInfoDTOValidator);
        private void EmailValidation() => RuleFor(x => x.DTO.Email).EmailAddress().WithMessage("Invalid email");

        #endregion
    }
}
