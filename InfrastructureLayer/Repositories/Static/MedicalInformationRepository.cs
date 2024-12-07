using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
namespace InfrastructureLayer.Repositories.Static
{
    public class MedicalInformationRepository : StaticGenericRepository<MedicalInformation>
    {

        public MedicalInformationRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
    
}