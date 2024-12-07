using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Features.Teachers.Commands.UpdateTeacher;
using ApplicationLayer.Interfaces;
using FluentValidation;

namespace ApplicationLayer.Features.Teacher.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherInfoCommand>
    {
        #region Field(s)
        private readonly ITeacherService _service;
        private readonly UpdateInfoDTOValidator _validator;

        #endregion

        #region Constructure(s)
        public UpdateTeacherCommandValidator(ITeacherService service)
        {
            _service = service;
            _validator = new UpdateInfoDTOValidator();
            ApplyValidationrules();
        }

        #endregion
        private void ApplyValidationrules()
        {
            TeacherNumberExistsValidation();

            UpdateDTOValidation();

        }

        #region Abstraction
        private void TeacherNumberExistsValidation()
         => RuleFor(c => c.TeacherNumber)
            .MustAsync(async (TeacherNumber, cancellationToken) => await _service.IsExistsByTeacherNumber(TeacherNumber))
            .WithMessage(Command => $"Teacher with number '{Command.TeacherNumber}' not found!");
        private void UpdateDTOValidation()
            => RuleFor(s => s.DTO).SetValidator(_validator);


        #endregion

    }
}
