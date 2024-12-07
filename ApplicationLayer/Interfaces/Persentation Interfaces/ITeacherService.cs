using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Features.Teachers.Commands.AddNewTeacher;
using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface ITeacherService : IPersonExistsService, IsExistsTeacherSrevice
    {
        #region Action Method(s)
        IQueryable<Teacher> GetById(int id);
        IQueryable<Teacher> GetByTeacherNumber(string TeacherNumber);
        IQueryable<Teacher> GetByNationalNO(string NationalNo);
        IQueryable<Teacher> GetTeacherPage(int pageNumber);

        Task<bool> AddAsync(AddTeacherDTO entity);
        Task<bool> UpdateTeacherInfoAsync(string TeacherNumber, UpdateInfoDTO entity);
        Task<bool> AddRangeAsync(ICollection<Teacher> entities);
        Task<bool> UpdateRange(ICollection<Teacher> entities);

        // Task<bool> IsExistsByTeacherNumber(string TeacherNumber);
        Task<PaginatingResult> GetPaginateInfo();
        Task<bool> ChangePasswordAsync(string TeacherNumber, string CurrentPassword, string NewPassword);
        //Task<bool> ChangePassword(string UserName, string NewPassword);
        Task<bool> DeleteAsync(Teacher teacher);

        #endregion
    }
}
