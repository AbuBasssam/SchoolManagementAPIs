using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Static
{
    public class RefreshTokenRepository : GenericRepository<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Field(s)
        #endregion

        #region Constructor(s)
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual IQueryable<UserRefreshToken> GetTableNoTracking()
        {
            return _set.AsNoTracking().AsQueryable();
        }
        public async Task<bool> IsExistsByUserName(string UserName)
        {
            return await _set.AnyAsync(s => s.User!.UserName!.Equals(UserName) && s.IsUsed);
        }
        #endregion

        #region Methods

        #endregion
    }
}
