using ApplicationLayer.Comman;
using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Features.SectionFeature.Queries.GetSectionsPage;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Section.Queries.GetSectionsPage
{
    public class GetSectionsListQueryHandler : IRequestHandler<GetSectionsPageQuery, PaginatedResult<SectionQueryDTO>>
    {
        #region Field(s)
        private readonly ISectionService _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetSectionsListQueryHandler(ISectionService classServices, IMapper mapper)
        {
            _mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<SectionQueryDTO>> Handle(GetSectionsPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of Sections from the service
            var Page = await _services.GetSectionsPage(request.PageNumber)
                .Select(SectionQueryHelper.SectionDTOMap())
                .ToListAsync(cancellationToken);

            //Checking
            if (Page == null || !Page.Any())
                return PaginatedResult<SectionQueryDTO>
                   .Create()
                   .WithSucceeded(false)
                   .WithMessages(new List<string> { $"No Sections found!" })
                   .Build();

            var PaginateInfo = await _services.GetPaginateInfo();

            return PaginatedResult<SectionQueryDTO>
                .Create()
                .WithSucceeded(true)
                .WithTotaCount(PaginateInfo.TotalCount)
                .WithCurrentPage(request.PageNumber)
                .WithTotalPages(PaginateInfo.NumberOfPages)
                .WithPageSize(Page.Count)
                .WithData(Page)
                .Build();
        }
        #endregion
    }
}
