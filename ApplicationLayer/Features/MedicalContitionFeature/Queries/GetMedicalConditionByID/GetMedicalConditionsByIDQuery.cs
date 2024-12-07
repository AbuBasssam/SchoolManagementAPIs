using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalConditionByID
{
    public class GetMedicalConditionsByIDQuery : IRequest<Response<MedicalContionQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Constructure(s)
        public GetMedicalConditionsByIDQuery(int id) => ID = id;

        #endregion

    }
}
