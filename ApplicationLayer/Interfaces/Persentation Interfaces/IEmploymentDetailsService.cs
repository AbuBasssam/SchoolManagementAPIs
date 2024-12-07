using ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails;
using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IEmploymentDetailsService
    {
        #region Action Method(s)
        IQueryable<EmploymentDetail> GetEmploymentDetailsPage(int PageNumber = 1);
        IQueryable<EmploymentDetail> GetById(int id);
        IQueryable<EmploymentDetail> GetByTeacherNumber(string TeacherNumber);

        Task<bool> IsExistsByTeacherIDAsync(int TeacherID);
        Task<bool> IsExistsByTeacherNumberAsync(string TeacherNumber);
        Task<bool> IsExistsByIdAsync(int id);
        // Task<bool> AddAsync(AddEmplyementDetailCommandDTO entity);
        Task<bool> UpdateAsync(string TeacherNumber, UpdateEmployementDetailsCommandDTO entity);
        // Task<bool> AddRangeAsync(ICollection<AddEmplyementDetailCommandDTO> entities);
        Task<PaginatingResult> GetPaginateInfo();

        #endregion

        #region Idea(s)
        //Task<bool> UpdateRangeAsync(ICollection<EmploymentDetail> entities);
        //IQueryable<EmploymentDetail> GetEmployesByContractType(enContractType ContractType);
        //IQueryable<EmploymentDetail> GetEmployesByHiringDuration(DateTime StartDuration, DateTime EndDuration);
        //IQueryable<EmploymentDetail> GetEmployesBySalaryRange(double min, double max);
        //IQueryable<EmploymentDetail> GetEmployesMonthlyHiring(MonthOfYear Month);

        #endregion
    }
}
