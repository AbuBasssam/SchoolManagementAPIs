using ApplicationLayer.Interfaces;
using DomainLayer.Entities;

public interface IRefreshTokenRepository : IGenericRepository<UserRefreshToken>
{
    IQueryable<UserRefreshToken> GetTableNoTracking();
    Task<bool> IsExistsByUserName(string UserName);
}
