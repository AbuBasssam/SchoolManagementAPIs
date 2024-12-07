using DomainLayer.Contracts;

namespace ApplicationLayer.Interfaces
{
    public interface IGenericRepository<T> : IStaticGenericRepository<T> where T : class, IEntity
    {
        Task<bool> DeleteRange(ICollection<T> entities);
        Task<bool> DeleteAsync(T entity);
    }
}
