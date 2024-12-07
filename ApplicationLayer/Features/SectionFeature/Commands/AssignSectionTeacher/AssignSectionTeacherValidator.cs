using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.SectionFeature.Commands.AssignSectionTeacher
{
    public class AssignSectionTeacherValidator : AbstractValidator<AssignSectionTeacherCommand>
    {


        public AssignSectionTeacherValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.DTO.SectionNumber).ApplyNumericRuleWithFixedLength(4);

            RuleFor(x => x.DTO.TeacherNumber).ApplyNumericRuleWithFixedLength(10);


        }
    }
}

