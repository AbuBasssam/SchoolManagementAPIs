
using ApplicationLayer.Models;

namespace ApplicationLayer.Interfaces.Persentation_Interfaces
{
    public interface IMedicalConditioService
    {

        #region ActionMethod(s)
        IQueryable<MedicalCondition> GetMedicalConditionPage(int PageNumber = 1);
        IQueryable<MedicalCondition> GetById(int Id);
        IQueryable<MedicalCondition> GetByName(string ConditionName);
        Task<PaginatingResult> GetPaginateInfo();
        #endregion
    }

}
