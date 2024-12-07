using ApplicationLayer.Comman;
using ApplicationLayer.Features.User.Queries;
using MediatR;

namespace ApplicationLayer.Features
{
    public class GetUsersPageQuery : IRequest<PaginatedResult<UserQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetUsersPageQuery(int pageNumber) => PageNumber = pageNumber;

        #endregion
    }
}
