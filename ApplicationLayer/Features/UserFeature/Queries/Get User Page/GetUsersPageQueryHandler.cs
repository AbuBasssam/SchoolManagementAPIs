using ApplicationLayer.Comman;
using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features
{
    public class GetUsersPageQueryHandler : IRequestHandler<GetUsersPageQuery, PaginatedResult<UserQueryDTO>>
    {
        #region Field(s)
        private readonly IUserService _services;
        // private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetUsersPageQueryHandler(IUserService classServices)//, IMapper mapper
        {
            //_mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<UserQueryDTO>> Handle(GetUsersPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of Users from the service
            var Page = await _services.GetUsersPage(request.PageNumber).Select(UserQueryHelper.UserDTOMap()).ToListAsync(cancellationToken);

            //Checking
            if (Page == null || !Page.Any())
                return PaginatedResult<UserQueryDTO>.Create().WithSucceeded(false).WithMessages(new List<string> { $"No Users found!" }).Build();

            var PaginateInfo = await _services.GetPaginateInfo();



            return PaginatedResult<UserQueryDTO>
                .Create()
                .WithSucceeded(true)
                .WithData(Page)
                .WithTotaCount(PaginateInfo.TotalCount)
                .WithCurrentPage(request.PageNumber)
                .WithTotalPages(PaginateInfo.NumberOfPages)
                .WithPageSize(Page.Count)
                .Build();
        }


        #endregion
    }
}
