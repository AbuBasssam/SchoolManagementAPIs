using ApplicationLayer.Interfaces.DB_Interfaces;
using DomainLayer.Entities;
using DomainLayer.Enums;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Static
{
    public class EmployementDetailsRepository : StaticGenericRepository<EmploymentDetail>, IEmploymentDetailsRepository
    {

        public EmployementDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }


        public IQueryable<EmploymentDetail> GetByTeacherNumber(string TeacherNumber)
        {
            var User = _context.Set<User>()
                 .Where(u => u.UserName!.Equals(TeacherNumber) && u.Role.Equals(enRole.Teacher))
                 .SingleOrDefault();

            if (User == null)
                return _set.Where(t => false);

            var TeacherID = _context.Set<Teacher>().Where(t => t.UserID.Equals(User.Id)).Select(t => t.Id).Single();
            return _set.Where(t => t.TeacherID.Equals(TeacherID)).Include(e => e.Teacher).ThenInclude(u => u.UserInfo);
        }

        public IQueryable<EmploymentDetail> GetEmployesByContractType(enContractType ContractType) => _set.AsTracking().Where(e => e.ContractType.Equals(ContractType));


        public IQueryable<EmploymentDetail> GetEmployesByHiringDuration(DateTime StartDuration, DateTime EndDuration) => _set.AsNoTracking().Where(e => e.HiringDate >= StartDuration && e.HiringDate <= EndDuration);


        public IQueryable<EmploymentDetail> GetEmployesBySalaryRange(double min, double max) => _set.AsTracking().Where(e => e.Salary >= min && e.Salary <= max);


        public IQueryable<EmploymentDetail> GetEmployesMonthlyHiring(MonthOfYear Month) => _set.AsNoTracking().Where(e => e.HiringDate.Month == (int)Month);


        public async Task<bool> IsExistsByTeacherIDAsync(int TeacherID) => await _set.AnyAsync(e => e.TeacherID.Equals(TeacherID));


        public async Task<bool> IsExistsByTeacherNumberAsync(string TeacherNumber) => await _context.Set<User>().AnyAsync(u => u.UserName!.Equals(TeacherNumber) && u.Role.Equals(enRole.Teacher));

    }
}