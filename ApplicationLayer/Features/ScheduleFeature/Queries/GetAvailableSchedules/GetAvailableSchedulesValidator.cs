using ApplicationLayer.Features.SectionFeature.Commans.Validator;
using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules
{
    public class GetAvailableSchedulesValidator : AbstractValidator<GetAvailableSchedulesQueryDTO>
    {
        #region Field(s)

        #endregion
        public GetAvailableSchedulesValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.TimeSlot).SetValidator(new TimeSlotValidator());

            RuleFor(x => (int)x.TimesPerWeek).ApplyRangeRule(1, 4);


        }
    }

















}
