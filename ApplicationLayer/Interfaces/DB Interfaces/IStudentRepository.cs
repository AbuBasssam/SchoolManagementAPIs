using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IStudentRepository : IStaticGenericRepository<Student>
    {
        IQueryable<Student> GetByStudentNumber(string studentNumber);
        IQueryable<Student> GetByNationalNO(string NationalNo);
        Task<bool> IsExistsByStudentNumber(string StudentNumber);
        Task<bool> UpdateStudentInfo(string StudentNumber, Person entity);
        Task<bool> DeleteAsync(Student student);




    }




}
