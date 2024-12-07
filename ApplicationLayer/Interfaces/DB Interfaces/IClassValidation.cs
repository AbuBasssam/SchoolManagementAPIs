using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IClassValidation
    {
        IQueryable<Class> GetByName(string ClassName);

    }


}
