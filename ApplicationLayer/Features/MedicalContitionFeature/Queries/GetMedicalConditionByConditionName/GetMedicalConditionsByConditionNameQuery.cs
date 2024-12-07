using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalConditionByConditionName
{
    public class GetMedicalConditionsByConditionNameQuery : IRequest<Response<MedicalContionQueryDTO>>
    {
        #region Field(s)
        public string ConditionName { get; set; }

        #endregion

        #region Cnosturcture(s)
        public GetMedicalConditionsByConditionNameQuery(string conditionName) => ConditionName = conditionName;

        #endregion


    }
}
