using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.Enums;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Static
{
    public class TeacherRepository : StaticGenericRepository<Teacher>, ITeacherRepository, IPersonExistsService
    {
        #region Constructor(s)

        public TeacherRepository(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Actions
        public override IQueryable<Teacher> GetById(int id)
        => _set.Where(s => s.Id.Equals(id) && s.UserInfo.IsActive);
        public override IQueryable<Teacher> GetPage(int PageNumber = 1)
            => _set.AsNoTracking().Where(x => x.UserInfo.IsActive).OrderBy(x => EF.Property<int>(x, "Id")).Skip((PageNumber - 1) * 10).Take(10);

        public IQueryable<Teacher> GetByNationalNO(string NationalNo)
          => _set.Where(s => s.UserInfo.PersonInfo.NationalNO.Equals(NationalNo) && s.UserInfo.RoleID.Equals((int)enRole.Teacher) && s.UserInfo.IsActive);

        public IQueryable<Teacher> GetByUserName(string UserName)
            => _set.Where(t => t.UserInfo.UserName!.Equals(UserName) && t.UserInfo.RoleID.Equals((int)enRole.Teacher) && t.UserInfo.IsActive);

        public Task<bool> IsExistsByNationalNo(string NationalNo)
             => _set.AnyAsync(p => p.UserInfo.PersonInfo.NationalNO.Equals(NationalNo) && p.UserInfo.RoleID.Equals((int)enRole.Teacher) && p.UserInfo.IsActive);

        public async Task<bool> IsExistsByTeacherNumber(string TeacherNumber)
            => await _set.AnyAsync(x => x.UserInfo.UserName!.Equals(TeacherNumber) && x.UserInfo.RoleID.Equals((int)enRole.Teacher) && x.UserInfo.IsActive);



        public async Task<bool> UpdateTeacherInfo(string TeacherNumber, Person entity)
        {

            var Teacher = GetByUserName(TeacherNumber).Include(s => s.UserInfo).ThenInclude(ui => ui.PersonInfo).AsNoTracking().FirstOrDefault();

            if (Teacher != null)
            {
                Teacher.UserInfo.PersonInfo = entity;
                _set.Update(Teacher);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;

            //PeopleRepository repository = new PeopleRepository(_context);
            //return await repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(Teacher teacher)
        {
            return await _context.Set<User>().Where(u => u.Id == teacher.UserID)
                      .ExecuteUpdateAsync(updates => updates.SetProperty(u => u.IsActive, false)) > 0;
        }

        #endregion

        //public async override Task<int> AddAsync(Teacher entity)
        //{
        //    using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {

        //        try
        //        {

        //            PeopleRepository PersonRepo = new PeopleRepository(_context);

        //            entity.UserInfo.PersonID = await PersonRepo.AddAsync(entity.UserInfo.PersonInfo);

        //            entity.UserInfo = TeacherHelper.AddTeacherUserInfo(entity.UserInfo);

        //            UserRepository UserRepo = new UserRepository(_context);

        //            entity.UserInfo.Id = await UserRepo.AddAsync(entity.UserInfo);

        //            entity.UserID = entity.UserInfo.Id;

        //            await _set.AddAsync(entity);

        //            await _context.SaveChangesAsync();

        //            await transaction.CommitAsync();

        //            return entity.Id;


        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            await transaction.RollbackAsync();
        //            return 0;

        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            return 0;
        //        }

        //    }

        //}

        #region Abstraction

        #endregion
    }


}
