using ApplicationLayer.Features.Schedule.Queries;
using ApplicationLayer.Features.SectionFeature.Commans.Interface;

namespace ApplicationLayer.Features.SectionFeature.Commands.UpdateSectionSchedule
{
    public class UpdateSectionScheduleCommandDTO : ISectionCommand
    {
        #region var/prop(s)
        public string SectionNumber { get; set; }
        public ScheduleDTO Schedule { get; set; }

        #endregion

        #region Constructure(s)

        public UpdateSectionScheduleCommandDTO(string sectionNumber, ScheduleDTO schedule)
        {
            SectionNumber = sectionNumber;
            Schedule = schedule;
        }

        #endregion
    }
}
