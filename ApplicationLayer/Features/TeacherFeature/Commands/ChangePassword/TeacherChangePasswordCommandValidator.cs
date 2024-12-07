using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Teacher.Commands.ChangePassword
{
    public class TeacherChangePasswordCommandValidator : AbstractValidator<TeacherChangePasswordCommand>
    {
        public TeacherChangePasswordCommandValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            UserNameValidation();
        }

        private void UserNameValidation() => RuleFor(x => x.DTO.UserName).ApplyNumericRuleWithFixedLength(10);
    }
    
}

