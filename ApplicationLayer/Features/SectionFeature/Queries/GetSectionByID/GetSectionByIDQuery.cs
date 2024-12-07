using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Queries.GetSectionByID
{
    public class GetSectionByIDQuery : IRequest<Response<SectionQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Constructure(s)
        public GetSectionByIDQuery(int id)
        {
            ID = id;
        }
        #endregion
    }
}
