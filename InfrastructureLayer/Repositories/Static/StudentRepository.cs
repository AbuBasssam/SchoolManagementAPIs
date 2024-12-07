using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.Enums;
using FluentValidation;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Static
{
    public class StudentRepository : StaticGenericRepository<Student>, IStudentRepository, IPersonExistsService
    {

        #region Constructor(s)
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }

        #endregion
        public override IQueryable<Student> GetPage(int PageNumber = 1)
           => _set.AsNoTracking().Where(x => x.UserInfo.IsActive).OrderBy(x => EF.Property<int>(x, "Id")).Skip((PageNumber - 1) * 10).Take(10);
        #region Actions
        public override IQueryable<Student> GetById(int id)
                   => _set.Where(s => s.Id.Equals(id) && s.UserInfo.IsActive);
        public IQueryable<Student> GetByNationalNO(string NationalNo)
           => _set.Where(s => s.UserInfo.PersonInfo.NationalNO.Equals(NationalNo) && s.UserInfo.RoleID.Equals((int)enRole.Student) && s.UserInfo.IsActive);

        public IQueryable<Student> GetByStudentNumber(string studentNumber)
            => _set.Where(s => s.UserInfo.UserName!.Equals(studentNumber) && s.UserInfo.RoleID.Equals((int)enRole.Student) && s.UserInfo.IsActive);

        public async Task<bool> UpdateStudentInfo(string StudentNumber, Person entity)
        {
            var Student = GetByStudentNumber(StudentNumber).Include(s => s.UserInfo).ThenInclude(ui => ui.PersonInfo).AsNoTracking().FirstOrDefault();

            if (Student != null)
            {
                Student.UserInfo.PersonInfo = entity;

                _set.Update(Student);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;

            //PeopleRepository repository = new PeopleRepository(_context);
            //return await repository.UpdateAsync(entity);
        }

        public async Task<bool> IsExistsByNationalNo(string NationalNo)
            => await _set.AnyAsync(p => p.UserInfo.PersonInfo.NationalNO.Equals(NationalNo) && p.UserInfo.RoleID.Equals((int)enRole.Student) && p.UserInfo.IsActive);

        public async Task<bool> IsExistsByStudentNumber(string StudentNumber)
           => await _set.AnyAsync(u => u.UserInfo.UserName!.Equals(StudentNumber) && u.UserInfo.RoleID.Equals((int)enRole.Student) && u.UserInfo.IsActive);

        #endregion

        #region Abstraction

        private async Task<int> AddStudentInfo(int UserID)
        {
            var StudentInfo = new Student
            {
                EnrollmentDate = DateTime.Now,
                GradeLevel = enLevel.FirstGrade,
                UserID = UserID,
            };
            await _set.AddAsync(StudentInfo);
            await _context.SaveChangesAsync();
            return StudentInfo.Id;
        }

        private async Task<bool> UpdatePersonInfo(Person entity)
        {
            var PersonInfo = _context.Set<Person>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            return await _context.Set<User>().Where(u => u.Id == student.UserID) // Access related user
          .ExecuteUpdateAsync(updates => updates.SetProperty(u => u.IsActive, false)) > 0;
        }

        #endregion


        #region Old Function(s)
        /* public override async Task<int> AddAsync(Student entity)
         {
             using (var transaction = await _context.Database.BeginTransactionAsync())
             {

                 try
                 {

                     PeopleRepository PersonRepo = new PeopleRepository(_context);

                     entity.UserInfo.PersonID = await PersonRepo.AddAsync(entity.UserInfo.PersonInfo);

                     entity.UserInfo = StudentHelper.AddStudentUserInfo(entity.UserInfo);

                     UserRepository UserRepo = new UserRepository(_context);

                     entity.UserInfo.Id = await UserRepo.AddAsync(entity.UserInfo);


                     entity.Id = await AddStudentInfo(entity.UserInfo.Id);


                     await transaction.CommitAsync();

                     return entity.Id;

                 }
                 catch (DbUpdateException ex)
                 {
                     await transaction.RollbackAsync();
                     return 0;

                 }
                 catch (Exception ex)
                 {
                     await transaction.RollbackAsync();
                     return 0;
                 }

             }

         }*/

        #endregion


    }


}