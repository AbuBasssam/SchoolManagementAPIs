using DomainLayer.Helper_Classes;
using System.Linq.Expressions;

namespace ApplicationLayer.Features.Schedule.Queries
{
    public static class ScheduleQueryHelper
    {

        public static Expression<Func<DomainLayer.Entities.Schedule, ScheduleDTO>> ScheduleDTOMap()
        {

            return sch =>
                             new ScheduleDTO
                             (
                                 sch.Class.ClassName,
                                 new WeekSchedule
                                 {
                                     SUN = sch.WeekSchedule.SUN,
                                     MON = sch.WeekSchedule.MON,
                                     TUE = sch.WeekSchedule.TUE,
                                     WED = sch.WeekSchedule.WED,
                                     THU = sch.WeekSchedule.THU,

                                 },
                                 new TimeSlot()
                                 {
                                     StartTime = sch.TimeSlot.StartTime,
                                     EndTime = sch.TimeSlot.EndTime,
                                 }


                             );
        }








    }
}
