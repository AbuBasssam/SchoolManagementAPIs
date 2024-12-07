using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Interfaces;
using FluentValidation;

namespace ApplicationLayer.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentInfoCommand>
    {
        #region Field(s)
        private readonly IStudentService _service;
        private readonly UpdateInfoDTOValidator _validator;

        #endregion

        #region Constructure(s)
        public UpdateStudentCommandValidator(IStudentService service)
        {
            _service = service;
            _validator = new UpdateInfoDTOValidator();
            ApplyValidationrules();
        }

        #endregion
        private void ApplyValidationrules()
        {
            StudentNumberExistsValidation();

            UpdateDTOValidation();

        }

        #region Action

        private void StudentNumberExistsValidation()
        {
            RuleFor(c => c.StudentNumber)
            .MustAsync
            (
                async (StudentNumber, cancellationToken)
                => await _service.IsExistsByStudentNumber(StudentNumber)

            ).WithMessage(c => $"Student with number '{c.StudentNumber}' not found!");

        }
        private void UpdateDTOValidation()
            => RuleFor(s => s.DTO).SetValidator(_validator);


        #endregion

    }
}
