using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IPersonRepository : IStaticGenericRepository<Person>, IPersonExistsService
    {


    }
}
