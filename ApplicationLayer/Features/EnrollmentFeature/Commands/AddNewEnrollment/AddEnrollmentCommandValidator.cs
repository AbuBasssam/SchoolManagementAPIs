using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment
{
    public class AddEnrollmentCommandValidator : AbstractValidator<AddNewEnrollmentCommand>
    {
        #region Fields

        #endregion

        #region Constructor(s)
        public AddEnrollmentCommandValidator() => ApplyValidationrules();
        #endregion

        #region Actions
        public void ApplyValidationrules()
        {
            _StudentNumberValidation();

            _SectionNumberlValidation();

        }


        private void _SectionNumberlValidation()
            => RuleFor(c => c.DTO.SectionNumber).ApplyNumericRuleWithFixedLength(4);

        private void _StudentNumberValidation()
            => RuleFor(c => c.DTO.StudentNumber).ApplyNumericRuleWithFixedLength(10);





        #endregion

        #region Abstraction

        #endregion

    }
}
