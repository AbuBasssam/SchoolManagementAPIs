using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Teachers.Commands.AddNewTeacher
{
    public class AddTeacherCommandValidator : AbstractValidator<AddTeacherCommand>
    {
        #region Fields
        private readonly ITeacherService _service;
        private readonly AddInfoDTOValidator _InfoDTOValidator;
        private readonly UserInfoDTOValidator _UserInfoDTOValidator;

        #endregion

        #region Constructor(s)
        public AddTeacherCommandValidator(ITeacherService service)
        {
            _service = service;
            _InfoDTOValidator = new AddInfoDTOValidator();
            _UserInfoDTOValidator = new UserInfoDTOValidator();
            ApplyValidations();

        }

        private void ApplyValidations()
        {
            InfoValidation();
            UserInfoValidation();
            ContractTypeValidation();
        }

        private void ContractTypeValidation()
        {
            RuleFor(t => t.Teacher.DetailsDTO.ContractType).ApplyenContractTypeRule();
        }

        private void InfoValidation()
            => RuleFor(x => x.Teacher.InfoDTO).SetValidator(_InfoDTOValidator);
        private void UserInfoValidation()
           => RuleFor(x => x.Teacher.UserInfoDTO).SetValidator(_UserInfoDTOValidator);
        private void EmailValidation()
            => RuleFor(x => x.Teacher.AddTeacherInfoDTO.Email).EmailAddress();

        #endregion
    }
}
