using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces.Persentation_Interfaces
{
    public interface IClassServices
    {
        #region Action Method(s)
        IQueryable<Class> GetById(int id);
        IQueryable<Class> GetByName(string ClassName);

        IQueryable<Class> GetClassesPage(int PageNumber = 1);
        Task<bool> IsExistsByName(string ClassName);
        Task<IList<Class>> GetFilterClasses(FilterClasses filter);
        Task<PaginatingResult> GetPaginateInfo();

        #endregion

    }
}
