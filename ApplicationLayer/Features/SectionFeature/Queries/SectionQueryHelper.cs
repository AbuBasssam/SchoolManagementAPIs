using ApplicationLayer.Features.Schedule.Queries;
using System.Linq.Expressions;

namespace ApplicationLayer.Features.SectionFeature.Queries
{
    public static class SectionQueryHelper
    {
        public static Expression<Func<DomainLayer.Entities.Section, SectionQueryDTO>> SectionDTOMap()

           =>
           se => new SectionQueryDTO
           (
               se.SectionNumber,
               se.SectionType,
               se.Course.CourseCode,
               se.Course.CourseName,


               new ScheduleDTO
               (
                   se.Schedule.Class.ClassName,
                   se.Schedule.WeekSchedule,
                   se.Schedule.TimeSlot
               ),
                se.Teacher != null ? se.Teacher.UserInfo.PersonInfo.FullName : "Not Assigned Yet"
           );
        //public static Expression<Func<DomainLayer.Entities.Section, ScheduleView>> SectionViewDTOMap()

        //   =>
        //   se => new ScheduleView()
        //   {
        //       SectionNumber = se.SectionNumber,
        //       CourseCode = se.Course.CourseCode,
        //       ClassName = se.Course.CourseName,
        //       SUN = se.Schedule.WeekSchedule.SUN,
        //       MON = se.Schedule.WeekSchedule.MON,
        //       TUE = se.Schedule.WeekSchedule.TUE,
        //       WED = se.Schedule.WeekSchedule.WED,
        //       THU = se.Schedule.WeekSchedule.THU,
        //       StartTime = se.Schedule.TimeSlot.StartTime,
        //       EndTime = se.Schedule.TimeSlot.EndTime,


        //   };
    }
}
