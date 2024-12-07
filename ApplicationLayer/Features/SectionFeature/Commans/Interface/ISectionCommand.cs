using ApplicationLayer.Features.Schedule.Queries;

namespace ApplicationLayer.Features.SectionFeature.Commans.Interface
{
    public interface ISectionCommand
    {
        #region var/prop(s)

        public string SectionNumber { get; set; }
        public ScheduleDTO Schedule { get; set; }

        #endregion

    }
}
