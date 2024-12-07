using ApplicationLayer.Comman;
using MediatR;

namespace ApplicationLayer.Features.Classes.Queries.GetClassesList
{
    public class GetClassesPageQuery : IRequest<PaginatedResult<ClassQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetClassesPageQuery(int pageNumber = 1) => PageNumber = pageNumber;

        #endregion

    }
}
