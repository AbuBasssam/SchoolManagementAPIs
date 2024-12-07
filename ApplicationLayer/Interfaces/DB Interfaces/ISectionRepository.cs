using ApplicationLayer.Services;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;

namespace ApplicationLayer.Interfaces
{
    public interface ISectionRepository : IStaticGenericRepository<Section>, ICommanSectionValidation, ISectionValidation
    {

        IQueryable<Section> GetByNumber(string SectionNumber);

        IQueryable<Schedule> GetSectionSchedule(string SectionNumber);

        IQueryable<Schedule> GetSectionSchedule(int SectionID);


        IQueryable<Schedule> GetSectionScheduleHistory(int SectionID);

        IQueryable<Schedule> GetSectionScheduleHistory(string SectionNumber);

        Task<bool> CloseAsync(string SectionNumber);

        //Task<bool> IsExistsByNumberAsync(string SectionNumber);

        //Task<bool> CheckSectionScheduleConflict(Schedule Schedule);

        Task<List<ScheduleConflict>> CheckTeacherSchedulConflict(string TeacherNumber, Schedule SectionSchedule);

        Task<bool> UpdateSectionSchedule(string sectionNumber, Schedule schedule);

        Task<bool> AssignSectionTeacher(string SectionNumber, int TeacherID);


    }




}
