using ApplicationLayer.Comman;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Queries.GetSectionsPage
{
    public class GetSectionsPageQuery : IRequest<PaginatedResult<SectionQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetSectionsPageQuery(int pageNumber)
        {
            PageNumber = pageNumber;
        }

        #endregion
    }
}
