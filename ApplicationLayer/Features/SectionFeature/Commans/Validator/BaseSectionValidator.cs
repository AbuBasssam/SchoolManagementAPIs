using ApplicationLayer.Features.SectionFeature.Commans.Interface;
using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.SectionFeature.Commans.Validator
{
    public abstract class BaseSectionValidator<T> : AbstractValidator<T> where T : ISectionCommand
    {
        #region Field(s)

        /*private readonly ICommanSectionValidation _commanValidationService;
        private readonly IClassValidation _classValidation;
        private readonly ScheduleDTOValidator _scheduleValidator;*/

        #endregion

        #region Constructure(s)

        public BaseSectionValidator() => _ApplyValidationRules();

        #endregion

        #region Action(s)
        private void _ApplyValidationRules()
        {
            SectionNumberValidation();
            TimeSlotValidation();
        }

        protected void SectionNumberValidation()
            => RuleFor(c => c.SectionNumber).ApplyNumericRuleWithFixedLength(4);

        protected void TimeSlotValidation()
            => RuleFor(x => x.Schedule.TimeSlot).SetValidator(new TimeSlotValidator());

        #endregion

        #region OldWay
        /*public BaseSectionValidator(ICommanSectionValidation commanSectionValidation, IClassValidation classValidation)
       {
           _commanValidationService = commanSectionValidation;
           _classValidation = classValidation;
           _scheduleValidator = new ScheduleDTOValidator(commanSectionValidation, classValidation);
           _ApplyValidationRules();


       }*/

        /*private void _ApplyValidationRules()
        {
            SectionNumberValidation();

            //ScheduleConflictValidation();
            //TimeSlotValidation();
        }*/
        /* RuleFor(c => c.SectionNumber)
        .ApplyNotEmptyRule()
        .ApplyNotNullableRule()
        .DependentRules(() => { RuleFor(c => c.SectionNumber).ApplyNumericRuleWithFixedLength(4); });
       */
        /*protected void ScheduleConflictValidation() => RuleFor(x => x.Schedule).SetValidator(new ScheduleDTOValidator());
         */
        #endregion



    }
}
