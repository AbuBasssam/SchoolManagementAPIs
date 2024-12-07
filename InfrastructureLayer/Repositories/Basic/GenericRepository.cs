using ApplicationLayer.Interfaces;
using DomainLayer.Contracts;
using InfrastructureLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Basic
{
    public class GenericRepository<T> : StaticGenericRepository<T>, IGenericRepository<T> where T : class, IEntity
    {
        #region Constructor(s)
        public GenericRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion

        #region Actions
        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            //_context.Entry(entity).State = EntityState.Deleted;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRange(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            return await _context.SaveChangesAsync() > 0;




        }
        #endregion
    }
}