using ApplicationLayer.Comman;
using MediatR;


namespace ApplicationLayer.Features.EmplyementDetails.Queries
{
    public class GetEmplyementDetailsPageQuery : IRequest<PaginatedResult<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Contructure(s)
        public GetEmplyementDetailsPageQuery(int pageNumber) => PageNumber = pageNumber;

        #endregion
    }
}