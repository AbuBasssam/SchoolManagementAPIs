using ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;

namespace ApplicationLayer.Interfaces
{
    public interface IScheduleRepository : IStaticGenericRepository<Schedule>
    {

        IQueryable<Schedule>? GetActiveDaliySchedule(DayOfWeek day);


        IQueryable<Schedule> GetClassSchedule(int ClassID);


        IQueryable<Schedule> GetClassSchedule(string ClassName);


        IQueryable<Schedule> GetClassScheduleHistory(int ClassID);

        IQueryable<Schedule> GetClassScheduleHistory(string ClassName);





        Task<ICollection<WeekSchedule>> GetAvailableSchedules(GetAvailableSchedulesQueryDTO DTO);

    }




}
