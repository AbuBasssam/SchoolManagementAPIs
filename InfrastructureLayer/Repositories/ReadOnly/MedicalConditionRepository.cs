using ApplicationLayer.Interfaces;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace InfrastructureLayer.Repositories.ReadOnly
{
    public class MedicalConditionRepository : ReadOnlyRepository<MedicalCondition>, IMedicalConditionRepository
    {

        public MedicalConditionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<MedicalCondition> GetByName(string conditionName)
            => _set.AsNoTracking().Where(mc => mc.ConditionName == conditionName);
       


    }

}