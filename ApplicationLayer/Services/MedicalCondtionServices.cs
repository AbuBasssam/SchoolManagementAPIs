using ApplicationLayer.Interfaces;
using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;

namespace ApplicationLayer.Services
{

    public class MedicalCondtionServices : IMedicalConditioService
    {
        #region Fields

        private readonly IMedicalConditionRepository _MedicalConditions;
        #endregion

        #region Constructure(s)
        public MedicalCondtionServices(IMedicalConditionRepository  medicalConditionRepository)
        {
            _MedicalConditions = medicalConditionRepository;

        }
        #endregion

        #region Action Methods
        public IQueryable<MedicalCondition> GetMedicalConditionPage(int PageNumber=1) => _MedicalConditions.GetPage(PageNumber);


        public IQueryable<MedicalCondition> GetById(int id) => _MedicalConditions.GetById(id);

        public IQueryable<MedicalCondition> GetByName(string ConditionName) => _MedicalConditions.GetByName(ConditionName);

        public Task<PaginatingResult> GetPaginateInfo() => _MedicalConditions.GetPaginateInfo();


        #endregion

    }

}
