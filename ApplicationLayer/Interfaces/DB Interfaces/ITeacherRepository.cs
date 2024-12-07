using ApplicationLayer.Interfaces;
using DomainLayer.Entities;

public interface ITeacherRepository : IStaticGenericRepository<Teacher>, ITeacherExistsService
{
    //IQueryable<Teacher> GetByUserName(string UserName);

    IQueryable<Teacher> GetByNationalNO(string NationalNo);
    Task<bool> IsExistsByTeacherNumber(string TeacherNumber);
    Task<bool> IsExistsByNationalNo(string NationalNo);
    Task<bool> UpdateTeacherInfo(string TeacherNumber, Person entity);
    Task<bool> DeleteAsync(Teacher teacher);
}
