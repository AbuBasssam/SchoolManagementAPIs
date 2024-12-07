using ApplicationLayer.Enums;
using ApplicationLayer.Features.Courses;
using DomainLayer.Enums;
using FluentValidation;

namespace ApplicationLayer.Validations
{
    public static class ValidationruleExtension
    {
        public static IRuleBuilderOptions<T, TProperty> ApplyNotEmptyRule<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.NotEmpty().WithMessage("Required! {PropertyName} cannot be empty");

        public static IRuleBuilderOptions<T, string> ApplyAlphabeticOnlyRule<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder.Matches(@"^[A-Za-z\s]+$").WithMessage("This field cannot contain numbers or special characters.");

        public static IRuleBuilderOptions<T, TProperty> ApplyNotNullableRule<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.NotNull().WithMessage("Required! {PropertyName} cannot be null");

        public static IRuleBuilderOptions<T, string> ApplyMinLengthRule<T>(this IRuleBuilder<T, string> ruleBuilder, int MinLength)
            => ruleBuilder.MinimumLength(MinLength).WithMessage("{PropertyName}" + $" must be at least {MinLength} characters");

        public static IRuleBuilderOptions<T, string> ApplyMaxLengthRule<T>(this IRuleBuilder<T, string> ruleBuilder, int MaxLength)
            => ruleBuilder.MaximumLength(MaxLength).WithMessage("{PropertyName}" + $" must be less than or equal {MaxLength} characters");

        public static IRuleBuilderOptions<T, string> ApplyCommonStringRules<T>(this IRuleBuilder<T, string> ruleBuilder, int MinLength, int MaxLength)
            => ruleBuilder.ApplyNotEmptyRule().ApplyNotNullableRule().ApplyMinLengthRule(MinLength).ApplyMaxLengthRule(MaxLength);

        public static IRuleBuilderOptions<T, string> ApplyNumericRuleWithFixedLength<T>(this IRuleBuilder<T, string> ruleBuilder, int length)
            => ruleBuilder.Matches($@"^\d{{{length}}}$").WithMessage("{PropertyName}" + $" must be a numeric value with exactly {length} digits");

        public static IRuleBuilderOptions<T, int> ApplyRangeRule<T>(this IRuleBuilder<T, int> ruleBuilder, int min, int max)
            => ruleBuilder.InclusiveBetween(min, max).WithMessage("{PropertyName}" + $" must be between {min} and {max}");

        public static IRuleBuilderOptions<T, enCourseHours> ApplyCourseHoursRule<T>(this IRuleBuilder<T, enCourseHours> ruleBuilder)
            => ruleBuilder.Must(hours => (int)hours >= 2 && (int)hours <= 4).WithMessage(CourseHelper.CourseValidationMessages.CourseHoursErrorValidationMessage);

        public static IRuleBuilderOptions<T, enLevel> ApplyLevelRule<T>(this IRuleBuilder<T, enLevel> ruleBuilder, string errorMessage)
            => ruleBuilder.Must(level => (int)level >= 1 && (int)level <= 3).WithMessage(errorMessage);

        public static IRuleBuilderOptions<T, enGender> ApplyGenderRule<T>(this IRuleBuilder<T, enGender> ruleBuilder)
            => ruleBuilder.Must(gender => (int)gender >= 0 && (int)gender <= 1).WithMessage("Gender must be Male or Female");

        public static IRuleBuilderOptions<T, enNatinoality> ApplyNationalityRule<T>(this IRuleBuilder<T, enNatinoality> ruleBuilder)
            => ruleBuilder.Must(Nationality => (int)Nationality >= 1 && (int)Nationality <= 193).WithMessage("Nationality must be between " + 1 + " and " + 193);


        public static IRuleBuilderOptions<T, enType> ApplyenTypeRule<T>(this IRuleBuilder<T, enType> ruleBuilder)
            => ruleBuilder.Must(hours => (int)hours >= 0 && (int)hours <= 1).WithMessage("Course Hours must be Theory or Practical");

        public static IRuleBuilderOptions<T, enContractType> ApplyenContractTypeRule<T>(this IRuleBuilder<T, enContractType> ruleBuilder)
            => ruleBuilder.Must(cType => (int)cType >= 0 && (int)cType <= 1).WithMessage("Course Hours must be Part Time or Full Time");






    }

}
