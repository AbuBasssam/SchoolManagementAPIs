using ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules;
using ApplicationLayer.Models;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;

namespace ApplicationLayer.Interfaces
{
    public interface IScheduleService
    {
        #region Action Method(s)
        IQueryable<Schedule> GetSchedulesPage(int pageNumber);
        IQueryable<Schedule> GetBySectionID(int SectionID);
        IQueryable<Schedule> GetBySectionNumber(string SectionNumber);
        IQueryable<Schedule> GetById(int Id);


        Task<bool> AddAsync(Schedule entity);
        Task<bool> UpdateAsync(Schedule entity);
        Task<bool> AddRangeAsync(ICollection<Schedule> entities);
        Task<bool> UpdateRange(ICollection<Schedule> entities);

        Task<PaginatingResult> GetPaginateInfo();
        Task<ICollection<WeekSchedule>> GetAvailableSchedules(GetAvailableSchedulesQueryDTO DTO);

        //Task<bool> IsScheduleExistsBySectionNumber(string SectionNumber);
        //Task<bool> CheckSectionConflict(AddscheduleCommandDTO Schedule);
        //Task<bool> CheckTeacherConflict(string TeacherNumber);


        #endregion
    }
}
