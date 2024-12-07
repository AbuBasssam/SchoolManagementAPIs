using ApplicationLayer.Models;
using DomainLayer;
namespace ApplicationLayer.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IQueryable<T> GetById(int id);
        IQueryable<T> GetPage(int PageNumber=1);
        Task<PaginatingResult> GetPaginateInfo();
    }
}
