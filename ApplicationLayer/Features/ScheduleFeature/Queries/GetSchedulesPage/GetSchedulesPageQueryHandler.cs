using ApplicationLayer.Comman;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Schedule.Queries.GetSchedulesPage
{
    public class GetSchedulesPageQueryHandler : IRequestHandler<GetSchedulesPageQuery, PaginatedResult<ScheduleDTO>>
    {
        #region Field(s)
        private readonly IScheduleService _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetSchedulesPageQueryHandler(IScheduleService classServices, IMapper mapper)
        {
            _mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<ScheduleDTO>> Handle(GetSchedulesPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of Schedules from the service
            var Page = await _services.GetSchedulesPage(request.PageNumber)
                .Select(ScheduleQueryHelper.ScheduleDTOMap()).ToListAsync(cancellationToken);

            if (Page == null || !Page.Any())
                return PaginatedResult<ScheduleDTO>
                   .Create()
                   .WithSucceeded(false)
                   .WithMessages(new List<string> { $"No Schedules found!" })
                   .Build();

            var PaginateInfo = await _services.GetPaginateInfo();

            return PaginatedResult<ScheduleDTO>
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
