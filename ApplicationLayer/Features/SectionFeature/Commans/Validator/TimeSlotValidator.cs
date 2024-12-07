using DomainLayer.Helper_Classes;
using FluentValidation;
using System.Linq.Expressions;

namespace ApplicationLayer.Features.SectionFeature.Commans.Validator
{
    public class TimeSlotValidator : AbstractValidator<TimeSlot>
    {
        #region Constructure(s)

        public TimeSlotValidator() => ApplyValidations();

        #endregion

        #region Action(s)

        public void ApplyValidations()
        {
            _ValidateStartAndEndTimeRule();

            _StartTimeRangeValidation();

            _EndTimeRangeValidation();

            _AddBreakTimeValidation();

        }




        #endregion

        #region Abstraction


        private bool _IsNotBreakTime(TimeSpan time)
            => !(time >= new TimeSpan(9, 51, 0) && time <= new TimeSpan(10, 29, 0));

        private void _AddBreakTimeValidation()
        {
            RuleFor(x => x.StartTime).Must(_IsNotBreakTime).WithMessage("Invalid StartTime: It is a break time, schedule cannot be added.");

            RuleFor(x => x.EndTime).Must(_IsNotBreakTime).WithMessage("Invalid EndTime: It is a break time, schedule cannot be added.");
        }

        private void _ValidateStartAndEndTimeRule()
            => RuleFor(x => x.EndTime).Must((timeSlot, endTime) => endTime > timeSlot.StartTime).WithMessage("Invalid EndTime, it must be greater than StartTime.");

        private void _StartTimeRangeValidation()
            => _ValidateTimeRange(s => s.StartTime, new TimeSpan(12, 30, 0), "Invalid schedule time. Start time must be before 12:31 PM.");

        private void _EndTimeRangeValidation()
            => _ValidateTimeRange(s => s.EndTime, new TimeSpan(13, 20, 0), "Invalid schedule time. End time must be before 1:20 PM.");

        private void _ValidateTimeRange(Expression<Func<TimeSlot, TimeSpan>> selector, TimeSpan cutoff, string errorMessage)
            => RuleFor(selector).Must(time => time <= cutoff).WithMessage(errorMessage);
        #endregion

        /* private void _StartTimeRangeValidation()
            => RuleFor(s => s.StartTime).Must(_IsBefore12_30PM).WithMessage("Invalid schedule time. Start time must be before 12:31 PM.");
        */

        /* private void _EndTimeRangeValidation()
             => RuleFor(s => s.EndTime).Must(_IsBefore1_20PM).WithMessage("Invalid schedule time. End time must be before 1:20 PM.");
         */

        /*private bool _IsBefore12_30PM(TimeSpan time) => time <= new TimeSpan(12, 30, 0);
         */

        /*private bool _IsBefore1_20PM(TimeSpan time) => time <= new TimeSpan(01, 20, 0);
         */
    }
}
