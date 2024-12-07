using ApplicationLayer.Features.SectionFeature.Commans.Validator;
using FluentValidation;

namespace ApplicationLayer.Features.SectionFeature.Commands.UpdateSection
{
    public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionScheduleCommand>
    {
        #region Fields
        //private readonly ISectionValidation _setionValidation;
        //private readonly ICommanSectionValidation _commanValidationService;
        //private readonly IClassValidation _classValidation;
        // private  UpdateSectionCommandDTOValidator _rules;
        #endregion

        #region Constructor(s)
        public UpdateSectionCommandValidator() => ApplyValidationrules();

        #endregion

        #region Actions
        public void ApplyValidationrules() => _CommanValidations();//_SectionExistsValidation();

        private void _CommanValidations() => RuleFor(x => x.DTO).SetValidator(new UpdateSectionCommandDTOValidator());

        #endregion

        #region OldWay

        /*public UpdateSectionCommandValidator(ISectionValidation setionValidation, ICommanSectionValidation commanSectionValidation, IClassValidation classValidation)
        {
            _setionValidation = setionValidation;
            _classValidation = classValidation;
            _commanValidationService = commanSectionValidation;
            _rules = new UpdateSectionCommandDTOValidator(commanSectionValidation, classValidation);
            ApplyValidationrules();

        }*/

        /*public void ApplyValidationrules()
        {
            _CommanValidations();

            //_SectionExistsValidation();

        }*/

        //private void _SectionExistsValidation()
        //{
        //    RuleFor(c => c.DTO.SectionNumber)
        //        .MustAsync(async (SectionNumber, cancellationToken) => await _setionValidation.IsExistsByNumberAsync(SectionNumber))
        //       .WithMessage(command => $"Section with number {command.DTO.SectionNumber} is not found !");
        //}

        #endregion


    }


}