using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface INationalityRepository : IReadOnlyRepository<Nationality>
    {
        IQueryable<Nationality> GetByName(string NationalityName);

    }
}
