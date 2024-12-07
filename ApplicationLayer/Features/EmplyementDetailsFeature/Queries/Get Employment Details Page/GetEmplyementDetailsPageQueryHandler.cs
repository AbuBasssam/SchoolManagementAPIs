using ApplicationLayer.Comman;
using ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByID;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ApplicationLayer.Features.EmplyementDetails.Queries

{
    public class GetEmplyementDetailsPageQueryHandler : IRequestHandler<GetEmplyementDetailsPageQuery, PaginatedResult<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        private readonly IEmploymentDetailsService _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)
        public GetEmplyementDetailsPageQueryHandler(IEmploymentDetailsService classServices, IMapper mapper)
        {
            _mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<EmplyementDetailQueryDTO>> Handle(GetEmplyementDetailsPageQuery request, CancellationToken cancellationToken)
        {

            // Fetch the list of EmplyementDetails from the service
            var Page = await _services.GetEmploymentDetailsPage(request.PageNumber)
                .Select(EmploymentDetailsQueryHelper.EmploymentDetailsDTOMap())
                .ToListAsync(cancellationToken);

            //Checking
            if (Page == null || !Page.Any())
                return PaginatedResult<EmplyementDetailQueryDTO>
                    .Create().WithSucceeded(false).WithMessages(new List<string> { $"No details found!" }).Build();


            var PaginateInfo = await _services.GetPaginateInfo();


            return PaginatedResult<EmplyementDetailQueryDTO>
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