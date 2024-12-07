using ApplicationLayer.Features.SectionFeature.Commands;
using ApplicationLayer.Features.SectionFeature.Commands.UpdateSection;
using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Services
{
    public interface ISectionService
    {
        #region Action Method(s)
        IQueryable<Section> GetById(int id);
        IQueryable<Section> GetByNumber(string SectionNumber);
        IQueryable<Section> GetSectionsPage(int pageNumber = 1);
        IQueryable<Schedule> GetSectionSchedule(string SectionNumber);

        Task<bool> IsExistsByIdAsync(int id);

        Task<bool> IsExistsByNumberAsync(string SectionNumber);
        Task<bool> AddAsync(AddSectionCommandDTO entity);

        Task<bool> UpdateAsync(Section entity);
        Task<bool> AddRangeAsync(ICollection<Section> entities);
        Task<bool> UpdateRangeAsync(ICollection<Section> entities);
        Task<bool> CloseAsync(string SectionNumber);

        Task<bool> CheckSectionScheduleConflict(Schedule Schedule);
        Task<bool> UpdateSectionSchedule(UpdateSectionCommandDTO DTO);
        Task<PaginatingResult> GetPaginateInfo();
        Task<bool> AssignSectionTeacher(string SectionNumber, string TeacherNumber);
        #endregion                      
    }
}
