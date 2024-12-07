using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Students.Commands.ChangePassword
{
    public class StudentChangePasswordCommandValidator : AbstractValidator<StudentChangePasswordCommand>
    {
        public StudentChangePasswordCommandValidator() => ApplyValidationRules();

        public void ApplyValidationRules()
        {
            UserNameValidation();
        }

        private void UserNameValidation()
            => RuleFor(x => x.DTO.UserName).ApplyNumericRuleWithFixedLength(10);
    }
}
