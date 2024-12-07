using ApplicationLayer.Features.Schedule.Queries;
using FluentValidation;

namespace ApplicationLayer.Features.SectionFeature.Commans.Validator
{
    public class ScheduleDTOValidator : AbstractValidator<ScheduleDTO>
    {
        #region Field(s)

        /* private readonly ICommanSectionValidation _sectionValidation;
         private readonly IClassValidation _classValidation;*/
        #endregion

        #region Constructure(s)

        public ScheduleDTOValidator() => _ApplyValidatioinRules();
        /*public ScheduleDTOValidator(ICommanSectionValidation service, IClassValidation classServices)
        {
            _sectionValidation = service;
            _classValidation = classServices;
            _ApplyValidatioinRules();
        }*/

        #endregion

        #region Action(s)
        private void _ApplyValidatioinRules()
        {
            //   _ScheduleDTOValidations();

        }

        /* private void _ScheduleDTOValidations()
         {
             _ClassExistsValidation()
                 .DependentRules(() => { _ApplyconflictValidation(); });

         }*/

        /*private void _ApplyconflictValidation()
        {
            RuleFor(c => c).MustAsync
                (
                    async (Schedule, cancellationToken) =>
                    {
                        var domainSchedule = new DomainLayer.Entities.Schedule
                        {
                            Class = new Class { ClassName = Schedule.ClassName },
                            WeekSchedule = Schedule.WeekSchedule,
                            TimeSlot = Schedule.TimeSlot,
                        };

                        return !await _sectionValidation.CheckSectionScheduleConflict(domainSchedule);
                    }


                ).WithMessage("there is a schedule conflict");
        }*/

        /*private IRuleBuilderOptions<ScheduleDTO, string> _ClassExistsValidation()
        {
            return RuleFor(c => c.ClassName).MustAsync
                                       (
                                           async (className, cancellationToken) =>
                                           {
                                               return await _classValidation.IsExistsByName(className);
                                           }
                                       ).WithMessage(c => $"Class with Name {c.ClassName} not exists");
        }*/

        #endregion
    }
}
