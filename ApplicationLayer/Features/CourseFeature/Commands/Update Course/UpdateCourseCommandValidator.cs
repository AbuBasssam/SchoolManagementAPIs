using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Courses.Commands.Update_Course
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        #region Fields
        //private readonly ICourseService _service;
        #endregion

        #region Constructor(s)
        public UpdateCourseCommandValidator() => ApplyValidationrules();

        #endregion

        #region Actions
        public void ApplyValidationrules()
        {
            //  CourseExistsValidation();

            _CourseHoursValidation();

            _CourseLevelValidation();

        }

        //Course Level: Should be between 1 and 3
        private void _CourseLevelValidation()
            => RuleFor(c => c.DTO.CourseLevel).ApplyLevelRule(CourseHelper.CourseValidationMessages.CourseLevelValidationErrorMessage);

        //Course Hours: Should be between 2 and 4
        private void _CourseHoursValidation() => RuleFor(c => c.DTO.CourseHours).ApplyCourseHoursRule();

        // Move to service layer begin
        /*private void CourseExistsValidation()
        {
            RuleFor(Command => Command.CourseCode)
                .MustAsync
                (
                    async (CourseCode, cancelationToken)
                        => await _service.IsExistsByCodeAsync(CourseCode)

                ).WithMessage(CourseCode => $"Course With {CourseCode.CourseCode} is not exists !");
        }*/

        //End
        #endregion

    }


}

