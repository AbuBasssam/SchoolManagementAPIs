namespace ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails
{
    /* public class AddEmployeeDetailCommandValidator : AbstractValidator<AddEmployeeDetailCommand>
     {
         #region Fields

         #endregion

         #region Constructor(s)
         public AddEmployeeDetailCommandValidator() => ApplyValidationrules();
         #endregion

         #region Actions
         public void ApplyValidationrules()
         {
             HiringDateValidation();
             ContractTypeValidation();
             TeacherNumberValidation();

             //TeacherNumberExistsValidation();
             //UniqueTeacherNumberConstraint();
         }

         private void HiringDateValidation()
         {
             RuleFor(ed => ed.DTO.HiringDate).ApplyNotEmptyRule()
                 .ApplyNotNullableRule()
                 .DependentRules
                 (() =>
                     {
                         RuleFor(ed => ed.DTO.HiringDate)
                         .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.Date))
                         .WithMessage("invalid date.");
                     }
                 );
         }

         private void ContractTypeValidation() => RuleFor(c => c.DTO.ContractType).ApplyenContractTypeRule();

         private void TeacherNumberValidation() => RuleFor(c => c.DTO.TeacherNumber).ApplyNumericRuleWithFixedLength(10);


         #endregion

     }*/


    /*private void UniqueTeacherNumberConstraint()
             => RuleFor(c => c.DTO.TeacherNumber)
                .MustAsync
             (
                 async (TeacherNumber, cancellationToken)
                 => !await _service.IsExistsByTeacherNumberAsync(TeacherNumber)

             ).WithMessage(Command => $"Teacher with number {Command.DTO.TeacherNumber} already have  details!");
         */


    /*private void TeacherNumberExistsValidation()
         => RuleFor(c => c.DTO.TeacherNumber)
            .MustAsync
         (
             async (TeacherNumber, cancellationToken)
             => await _teacherService.IsExistsByTeacherNumber(TeacherNumber)

         ).WithMessage(c => $"Teacher with number '{c.DTO.TeacherNumber}' not found!");
     */
}
