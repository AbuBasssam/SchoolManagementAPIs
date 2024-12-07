using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Static
{
    public class PeopleRepository : GenericRepository<Person>, IPersonRepository
    {
        #region Constructor(s)
        public PeopleRepository(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Actions

        public async Task<bool> IsExistsByNationalNo(string NationalNo) => await _set.AnyAsync(p => p.NationalNO.Equals(NationalNo));

        #endregion


    }

}