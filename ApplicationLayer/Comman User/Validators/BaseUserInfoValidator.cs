using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Students.Helper
{
    public abstract class BaseUserInfoValidator<T> : AbstractValidator<T> where T : IUserInfo
    {
        #region Constructure(s)

        protected BaseUserInfoValidator() : base()
        {
            ApplyCommonValidationRules();
        }

        #endregion

        #region Action(s)
        private void ApplyCommonValidationRules()
        {
            //  PasswordValidation();
            SaudiMobileValidation();
            ConfirmPasswordMatchingVlaidation();
        }

        private void ConfirmPasswordMatchingVlaidation()
            => RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("the ConfirmPassword not match password try again");

        // Move to service Layer
        // begin
        /* private void PasswordValidation()
         {
             RuleFor(x => x.Password)
                 .ApplyMinLengthRule(8)
                 .ApplyMaxLengthRule(16)
                 .DependentRules
                 (() =>
                     {
                         RuleFor(x => x.Password)
                         .Matches(@"[A-Z]")
                         .WithMessage("Password must contain at least one uppercase letter.")

                         .Matches(@"\d")
                         .WithMessage("Password must contain at least one number.")

                         .Matches(@"[!@#$%^&*(),.?""{}|<>]")
                         .WithMessage("Password must contain at least one punctuation character.");
                     }
                 );
         }*/
        // end
        private void SaudiMobileValidation()
            => RuleFor(x => x.PhoneNumber).ApplyNotEmptyRule().ApplyNotNullableRule().DependentRules(() => { _PhoneNumberValidation(); });


        private void _PhoneNumberValidation()
        {
            RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+966 5[0345689] \d{3} \d{4}$")
            .WithMessage("Phone number must be a valid Saudi mobile number in the format '+966 5XXXX XXXX'.");
        }
        #endregion
    }
}
