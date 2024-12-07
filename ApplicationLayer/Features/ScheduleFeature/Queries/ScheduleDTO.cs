using DomainLayer.Helper_Classes;

namespace ApplicationLayer.Features.Schedule.Queries
{
    public class ScheduleDTO
    {
        #region var/prop(s)
        public string ClassName { get; set; }
        public WeekSchedule WeekSchedule { get; set; }
        public TimeSlot TimeSlot { get; set; }

        #endregion

        #region Constructure(s)
        public ScheduleDTO(string className, WeekSchedule weekSchedule, TimeSlot timeSlot)
        {
            ClassName = className;
            WeekSchedule = weekSchedule;
            TimeSlot = timeSlot;
        }

        #endregion
    }
}
