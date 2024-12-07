using DomainLayer.Helper_Classes;

namespace ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules
{
    public class GetAvailableSchedulesQueryDTO
    {
        #region Field(s)
        public string ClassName { get; set; }
        public byte TimesPerWeek { get; set; }
        public TimeSlot TimeSlot { get; set; }

        #endregion

        #region Constructure(s)
        public GetAvailableSchedulesQueryDTO(string className, byte timesPerWeek, TimeSlot timeSlot)
        {
            ClassName = className;
            TimesPerWeek = timesPerWeek;
            TimeSlot = timeSlot;
        }

        #endregion
    }
}
