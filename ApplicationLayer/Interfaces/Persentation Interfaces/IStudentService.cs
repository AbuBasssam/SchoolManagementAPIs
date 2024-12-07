using ApplicationLayer.Features.Students.Commands.AddNewStudent;
using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IStudentService : IPersonExistsService
    {
        #region Action Method(s)
        IQueryable<Student> GetById(int Id);
        IQueryable<Student> GetByStudentNumber(string studentNumber);
        IQueryable<Student> GetByNationalNO(string NationalNo);
        IQueryable<Student> GetStudentsPage(int pageNumber);

        Task<bool> AddAsync(AddStudentDTO entity);
        Task<bool> UpdateStudentInfoAsync(string StudentNumber, UpdateInfoDTO entity);
        Task<bool> AddRangeAsync(ICollection<Student> entities);
        Task<bool> UpdateRange(ICollection<Student> entities);
        public Task<bool> IsExistsById(int Id);
        public Task<bool> IsExistsByStudentNumber(string StudentNumber);
        Task<bool> ChangePasswordAsync(string UserName, string CurrentPassword, string NewPassword);
        Task<PaginatingResult> GetPaginateInfo();
        Task<bool> DeleteAsync(Student student);

        #endregion
    }
}
