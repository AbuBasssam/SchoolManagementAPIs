using ApplicationLayer.Features.Schedule.Queries;
using ApplicationLayer.Features.SectionFeature.Commans.Interface;

namespace ApplicationLayer.Features.SectionFeature.Commands.UpdateSection
{
    public class UpdateSectionCommandDTO : ISectionCommand
    {
        #region Field(s)
        public string SectionNumber { get; set; }

        public ScheduleDTO Schedule { get; set; }

        #endregion

        #region Constructure(s)
        public UpdateSectionCommandDTO(string sectionNumber, ScheduleDTO scheduleDTO)
        {
            SectionNumber = sectionNumber;
            Schedule = scheduleDTO;
        }

        #endregion

    }




}