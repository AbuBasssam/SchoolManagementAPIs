using ApplicationLayer.Comman;
using MediatR;

namespace ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalContionsList
{
    public class GetMedicalConditionsPageQuery : IRequest<PaginatedResult<MedicalContionQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetMedicalConditionsPageQuery(int pageNumber) => PageNumber = pageNumber;

        #endregion
    }

}
