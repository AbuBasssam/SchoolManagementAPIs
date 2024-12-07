using ApplicationLayer.Models;
using DomainLayer.Entities;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.DB_Interfaces
{
    public interface IEmploymentDetailsRepository: IStaticGenericRepository<EmploymentDetail>
    {
        IQueryable<EmploymentDetail> GetByTeacherNumber(string TeacherNumber);
        Task<bool> IsExistsByTeacherIDAsync(int TeacherID);
        Task<bool> IsExistsByTeacherNumberAsync(string TeacherNumber);
        IQueryable<EmploymentDetail> GetEmployesByContractType(enContractType ContractType);
        IQueryable<EmploymentDetail> GetEmployesByHiringDuration(DateTime StartDuration,DateTime EndDuration);
        IQueryable<EmploymentDetail> GetEmployesMonthlyHiring(MonthOfYear Month);
        IQueryable<EmploymentDetail> GetEmployesBySalaryRange(double min, double max);
       // IQueryable<EmploymentDetail>GetEmploymentDetailsPage(int PageNumber=1);







    }
}
