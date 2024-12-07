using ApplicationLayer.Models;
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApplicationLayer.Interfaces
{
    public interface IStaticGenericRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetById(int id);
        IQueryable<T> GetPage(int PageNumber = 1);

        Task<bool> IsExistsByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> AddRangeAsync(ICollection<T> entities);
        Task<bool> UpdateRangeAsync(ICollection<T> entities);
        Task<PaginatingResult> GetPaginateInfo();
        IDbContextTransaction BeginTransaction();


    }
}
