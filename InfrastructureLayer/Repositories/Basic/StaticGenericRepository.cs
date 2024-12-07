using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Contracts;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InfrastructureLayer.Repositories.Basic
{
    public class StaticGenericRepository<T> : IStaticGenericRepository<T> where T : class, IEntity
    {
        #region Vars / Props
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _set;
        #endregion

        #region Constructor(s)
        public StaticGenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }
        #endregion

        #region Actions
        public virtual IQueryable<T> GetById(int id)
            => _set.Where(x => EF.Property<int>(x, "Id") == id);



        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task<bool> AddRangeAsync(ICollection<T> entities)
        {
            await _set.AddRangeAsync(entities);
            return true;
        }


        public virtual async Task<bool> UpdateRangeAsync(ICollection<T> entities)
        {
            _set.UpdateRange(entities);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsExistsByIdAsync(int id)
            => await _set.AnyAsync(s => s.Id == id);

        public async Task<PaginatingResult> GetPaginateInfo() => await ContextHelper<T>.PageInfo(_set);

        public virtual IQueryable<T> GetPage(int PageNumber = 1)
                  => _set.AsNoTracking().OrderBy(x => EF.Property<int>(x, "Id")).Skip((PageNumber - 1) * 10).Take(10);


        public virtual IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

        #endregion
    }


}
