using ApplicationLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer.Context;
using DomainLayer.Contracts;
using ApplicationLayer.Comman;
using ApplicationLayer.Models;
using InfrastructureLayer.Repositories.Helper;
namespace InfrastructureLayer.Repositories.Basic
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class, IEntity
    {
        #region Vars / Props
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _set;
        #endregion

        #region Constructor(s)
        public ReadOnlyRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }
        #endregion

        #region Actions
        public virtual IQueryable<T> GetById(int Id) => _set.AsNoTracking().Where(x => EF.Property<int>(x, "Id") == Id);

        public virtual IQueryable<T> GetPage(int PageNumber = 1)
            => _set.AsNoTracking().OrderBy(x => EF.Property<int>(x, "Id")).Skip((PageNumber-1)*10).Take(10).AsQueryable();

        public async Task<PaginatingResult> GetPaginateInfo() =>await ContextHelper<T>.PageInfo(_set);
           

        

        #endregion
    }


}
