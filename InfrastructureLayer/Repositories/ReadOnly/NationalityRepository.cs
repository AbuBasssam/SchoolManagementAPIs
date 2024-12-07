using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.ReadOnly
{
    public class NationalityRepository : ReadOnlyRepository<Nationality>, INationalityRepository
    {

        public NationalityRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<Nationality> GetByName(string nationalityName)
          => _set.AsNoTracking().Where(n => n.NationalityName == nationalityName);
       


    }
}