using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IClassRepository : IReadOnlyRepository<Class>, IClassValidation
    {
        // IQueryable<Class> GetByName(string ClassName);

        Task<IList<Class>> GetClassesFilter(FilterClasses filter);
        Task<bool> IsExistsByName(string className);
    }


}



