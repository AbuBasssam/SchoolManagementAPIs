using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails
{
    public class UpdateEmployementDetailsCommandValidator : AbstractValidator<UpdateEmplyementDetailCommand>
    {
        #region Field(s)
        //private readonly IEmploymentDetailsService _service;
        //ITeacherService _teacherService;

        #endregion

        #region Constructure(s)
        public UpdateEmployementDetailsCommandValidator() => ApplyValidationrules();
        #endregion

        public void ApplyValidationrules()
        {
            _ContractTypeValidation();

            _SalaryValidation();

            _TeacherNumberValidation();

            //TeacherNumberExistsValidation();

        }

        private void _ContractTypeValidation()
          => RuleFor(c => c.DTO.ContractType).ApplyenContractTypeRule();
        private void _SalaryValidation()
            => RuleFor(e => e.DTO.Salary).Must(_BeAValidNumeric).WithMessage("Salary must be a numeric value and cannot be negative");
        private void _TeacherNumberValidation()
            => RuleFor(e => e.TeacherNumber).ApplyNumericRuleWithFixedLength(10);


        // Check if the salary is a valid numeric value
        // Assuming salary should be non-negative
        private bool _BeAValidNumeric(double salary) => salary >= 0;


        /* private void TeacherNumberExistsValidation()
             => RuleFor(c => c.TeacherNumber)
                .MustAsync
             (
                 async (teacherNumber, cancellationToken)
                 => await _teacherService.IsExistsByTeacherNumber(teacherNumber)

             ).WithMessage(c => $"Teacher with number '{c.TeacherNumber}' not found!");
        */
    }



}
