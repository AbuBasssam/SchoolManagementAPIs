using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByID
{
    public class GetEmplyementDetailByIDQuery : IRequest<Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Constructure
        public GetEmplyementDetailByIDQuery(int Id) => ID = Id;
        #endregion

    }
}