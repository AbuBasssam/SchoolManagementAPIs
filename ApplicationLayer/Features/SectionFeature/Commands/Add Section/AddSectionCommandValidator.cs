using ApplicationLayer.Features.SectionFeature.Commans.Validator;
using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.SectionFeature.Commands
{
    public class AddSectionCommandValidator : AbstractValidator<AddSectionCommand>
    {
        #region Fields

        //private readonly ICommanSectionValidation _commanSectionValidations;
        //private readonly ISectionValidation _setionValidation;
        //private readonly ICommanCourseValidation _courseValidation;
        //private readonly IClassValidation _classValidation;
        // private readonly AddSectionCommandDTOValidator _rules;

        #endregion

        #region Constructor(s)
        public AddSectionCommandValidator() => ApplyValidationrules();

        #endregion

        #region Actions
        public void ApplyValidationrules()
        {
            _CommandValidations();

            _SectionTypeValidation();

        }

        private void _CommandValidations() => RuleFor(c => c.DTO).SetValidator(new AddSectionCommandDTOValidator());

        private void _SectionTypeValidation() => RuleFor(s => s.DTO.SectionType).ApplyenTypeRule();

        #endregion

        #region OldWay

        /* public AddSectionCommandValidator(ICommanSectionValidation commanSectionValidations, ISectionValidation setionValidation,
       ICommanCourseValidation courseValidation, IClassValidation classValidation)
   {
       _commanSectionValidations = commanSectionValidations;
       _setionValidation = setionValidation;
       _courseValidation = courseValidation;
       _classValidation = classValidation;
       _rules = new AddSectionCommandDTOValidator(commanSectionValidations, classValidation);
       ApplyValidationrules();

   }*/

        /*private void _CourseValidations()
        {
            //Ensure Course Exists Validation is executed first
            RuleFor(c => c.DTO.CourseCode)
                .MustAsync(async (courseCode, cancellationToken) => await _courseValidation.IsExistsByCodeAsync(courseCode))
                .WithMessage(c => $"Course with Code '{c.DTO.CourseCode}' not found!")
                .DependentRules(() => { SectionTypeMatchesCourseValidation(); });
        }
        */

        /*  private void _UniqueSectionNumberConstraint()
            {
                RuleFor(c => c.DTO.SectionNumber)
                    .MustAsync
                    (
                        async (SectionNumber, cancellationToken)
                        => !await _setionValidation.IsExistsByNumberAsync(SectionNumber)

                    )
                    .WithMessage(SectionNumber => $"A Section with this number {SectionNumber} already exists!");
    }
    */

        /* private void SectionTypeMatchesCourseValidation()
        {
           RuleFor(c => c.DTO)
                .MustAsync
                (
                    async (section, cancellationToken) =>
                    {
                        var course = await _courseValidation.GetByCode(section.CourseCode).AsNoTracking().SingleAsync();
                        if (course == null)
                            return false;

                        // Validation logic: Practical section can only be added to courses that allow practicals.
                        return course.HasPractical || section.SectionType == enType.Theory;
                    }

                ).WithMessage(s => $"Cannot add a {s.DTO.SectionType} section to the course '{s.DTO.CourseCode}' which does not allow practicals.");
        }
        */

        #endregion
    }

}
