using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Students.Helper
{
    public abstract class BaseInfoValidator<T> : AbstractValidator<T> where T : IPersonInfo
    {
        protected BaseInfoValidator()
        {
            ApplyCommonValidationRules();
        }

        private void ApplyCommonValidationRules()
        {
            NameValidation();
            UnderAgeValidation();
            GenderValidation();
            NationalityValidation();
        }

        #region Action

        protected void NameValidation()
        {
            RuleFor(s => s.FirstName)
                .ApplyNotEmptyRule()
                .ApplyNotNullableRule()
                .DependentRules
                (() =>
                    {
                        RuleFor(s => s.FirstName)
                        .ApplyMaxLengthRule(20)
                        .ApplyAlphabeticOnlyRule();

                    }
                );



            RuleFor(s => s.SecondName)
               .ApplyNotEmptyRule()
               .ApplyNotNullableRule()
               .DependentRules
                (() =>
                    {
                        RuleFor(s => s.SecondName)
                        .ApplyMaxLengthRule(20)
                        .ApplyAlphabeticOnlyRule();

                    }
                );


            RuleFor(s => s.ThirdName)
              .ApplyNotEmptyRule()
              .ApplyNotNullableRule()
              .DependentRules
               (() =>
                    {
                        RuleFor(s => s.ThirdName)
                        .ApplyMaxLengthRule(20)
                        .ApplyAlphabeticOnlyRule();

                    }
               );


            RuleFor(s => s.LastName)
               .ApplyNotEmptyRule()
               .ApplyNotNullableRule()
               .DependentRules
                (() =>
                    {
                        RuleFor(s => s.LastName)
                        .ApplyMaxLengthRule(20)
                        .ApplyAlphabeticOnlyRule();

                    }
                );
        }

        protected void UnderAgeValidation()
        {
            RuleFor(s => s.DateOfBirth)
                .Must(dateOfBirth => dateOfBirth <= DateTime.Today.AddYears(-15))
                .WithMessage("The date of birth must be at least 15 years ago.");

        }

        protected void GenderValidation()
        {
            RuleFor(s => s.Gender).ApplyGenderRule();
        }

        protected void NationalityValidation()
        {
            RuleFor(s => s.Nationality).ApplyNationalityRule();
        }

        #endregion



    }
}
