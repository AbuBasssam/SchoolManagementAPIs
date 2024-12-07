using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Static
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Constructor(s)
        public UserRepository(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Actions
        public override IQueryable<User> GetById(int id)
            => _set.Where(x => x.Id.Equals(id) && x.IsActive);


        public virtual IQueryable<User> GetByUserName(string UserName)
            => _set.Where(x => x.UserName!.Equals(UserName) && x.IsActive);

        public IQueryable<User> GetUserByEmail(string email)
            => _set.Where(u => u.Email!.Equals(email) && u.IsActive);

        public Task<bool> IsExistsByEmailAsync(string email)
            => _set.AnyAsync(u => u.Email!.Equals(email) && u.IsActive);

        public Task<bool> IsExistsByUserNameAsync(string userName)
            => _set.AnyAsync(u => u.UserName!.Equals(userName) && u.IsActive);

        public async Task<bool> UpdateInfo(string userName, Person entity)
        {
            var User = GetByUserName(userName).Include(ui => ui.PersonInfo).AsNoTracking().FirstOrDefault();

            if (User != null)
            {
                User.PersonInfo = entity;

                _set.Update(User);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }


        #endregion


    }

}