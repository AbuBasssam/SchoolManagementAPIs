using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Interfaces;
using FluentValidation;

namespace ApplicationLayer.Features.Students.Commands.AddNewStudent
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _service;
        private readonly AddInfoDTOValidator _InfoDTOValidator;
        private readonly UserInfoDTOValidator _UserInfoDTOValidator;
        #endregion

        #region Constructor(s)
        public AddStudentCommandValidator(IStudentService service)
        {
            _service = service;
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

        }

        private void InfoValidation()
            => RuleFor(x => x.DTO.InfoDTO).SetValidator(_InfoDTOValidator);

        private void UserInfoValidation()
           => RuleFor(x => x.DTO.UserInfoDTO).SetValidator(_UserInfoDTOValidator);

        #endregion
    }
}
