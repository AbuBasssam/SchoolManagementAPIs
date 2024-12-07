using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Courses.Commands
{
    public class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
    {
        #region Fields

        #endregion

        #region Constructor(s)
        public AddCourseCommandValidator() => ApplyValidationrules();
        #endregion

        #region Actions
        public void ApplyValidationrules()
        {
            _CourseHoursValidation();

            _CourseLevelValidation();

            _CourseCodeValidation();

            _PrerequisiteCourseCodeValidation();

            _CourseNameValidation();

            //---------------------------

            //UniqueCourseNameConstraint();

            //UniqueCourseCodeConstraint();

            //PrerequisiteCourseExistsValidation();

        }


        //Course Leve: Should be between 1 and 3
        private void _CourseLevelValidation()
            => RuleFor(c => c.DTO.CourseLevel).ApplyLevelRule(CourseHelper.CourseValidationMessages.CourseLevelValidationErrorMessage);

        //Course Hours: Should be between 2 and 4
        private void _CourseHoursValidation()
            => RuleFor(c => c.DTO.CourseHours).ApplyCourseHoursRule();

        // Course Code: Should be three numbers-three letters Like 123-ABC
        private void _CourseCodeValidation()
        {
            RuleFor(c => c.DTO.CourseCode).ApplyNotEmptyRule()
            .DependentRules(() =>
            {
                RuleFor(c => c.DTO.CourseCode).Matches(CourseHelper.CourseCodeFormat)
                .WithMessage("{PropertyName} have " + CourseHelper.CourseValidationMessages.FormatValidationErrorMessage);
            });
        }

        private void _CourseNameValidation()
            => RuleFor(c => c.DTO.CourseName).ApplyNotEmptyRule().ApplyNotNullableRule();

        private void _PrerequisiteCourseCodeValidation()
        {

            RuleFor(c => c.DTO.PrerequisiteCourseCode).Matches(CourseHelper.CourseCodeFormat)
            .When(c => !string.IsNullOrWhiteSpace(c.DTO.PrerequisiteCourseCode))
            .WithMessage("{PropertyName} have " + CourseHelper.CourseValidationMessages.FormatValidationErrorMessage);

        }


        // Move to Service Layer
        //begin
        /*private void UniqueCourseCodeConstraint()
        {
            RuleFor(c => c.DTO.CourseCode)
                        .MustAsync
                        (
                            async (name, cancellationToken)
                            => !await _service.IsExistsByCodeAsync(name)

                        ).WithMessage(c => $"A course with this code {c.DTO.CourseCode} already exists!");
        }

        private void UniqueCourseNameConstraint()
        {
            RuleFor(c => c.DTO.CourseName)
            .MustAsync
            (
                async (name, cancellationToken)
                => !await _AddValidation.IsExistsByNameAsync(name)

            ).WithMessage(c => $"A course with this name {c.DTO.CourseName} already exists!");
        }

        private void PrerequisiteCourseExistsValidation()
        {
            RuleFor(c => c.DTO.PrerequisiteCourseCode)
            .MustAsync
            (
                async (courseCode, cancellationToken) =>
                await _service.IsExistsByCodeAsync(courseCode)
            )
            .When(c => !string.IsNullOrWhiteSpace(c.DTO.PrerequisiteCourseCode))
            .WithMessage(course => $"A Prerequisite Course with code {course.DTO.PrerequisiteCourseCode} does not exist!");

        }*/
        //end
        #endregion

        #region Abstraction
        // private string _Format() => @"^\d{3}-[A-Z]{3}$";

        #endregion

    }
}
