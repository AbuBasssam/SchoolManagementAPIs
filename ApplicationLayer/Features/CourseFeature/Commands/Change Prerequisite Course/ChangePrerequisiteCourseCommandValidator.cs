using FluentValidation;

namespace ApplicationLayer.Features.Courses.Commands.Update_Course
{

    public class ChangePrerequisiteCourseCommandValidator : AbstractValidator<ChangePrerequisiteCourseCommand>
    {
        #region Fields
        //private readonly ICourseService _service;
        #endregion

        #region Constructor(s)
        public ChangePrerequisiteCourseCommandValidator() => ApplyValidationrules();

        #endregion

        #region Actions
        public void ApplyValidationrules()
        {
            _CourseCodeValidation();

            _NewPrerequisiteCourseValidation();

        }


        private void _CourseCodeValidation() => RuleFor(c => c.DTO.CourseCode).Matches(CourseHelper.CourseCodeFormat)
                .WithMessage("{PropertyName} have " + CourseHelper.CourseValidationMessages.FormatValidationErrorMessage);

        private void _NewPrerequisiteCourseValidation() => RuleFor(c => c.DTO.PrerequisiteCourseCode).Matches(CourseHelper.CourseCodeFormat)
            .WithMessage("{PropertyName} have " + CourseHelper.CourseValidationMessages.FormatValidationErrorMessage);

        //private string _Format() => @"^\d{3}-[A-Z]{3}$";


    }

    #endregion
}

