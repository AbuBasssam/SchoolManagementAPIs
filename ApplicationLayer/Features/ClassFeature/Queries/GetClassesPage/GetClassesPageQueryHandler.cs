using ApplicationLayer.Comman;
using ApplicationLayer.Interfaces.Persentation_Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Classes.Queries.GetClassesList
{
    public class GetClassesPageQueryHandler : IRequestHandler<GetClassesPageQuery, PaginatedResult<ClassQueryDTO>>
    {
        #region Fields
        private readonly IClassServices _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetClassesPageQueryHandler(IClassServices classServices, IMapper mapper)
        {
            _mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)

        public async Task<PaginatedResult<ClassQueryDTO>> Handle(GetClassesPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the classes list from the service
            var classes = await _services.GetClassesPage(request.PageNumber).ToListAsync(cancellationToken);

            // Checking
            if (classes == null || !classes.Any())
                return PaginatedResult<ClassQueryDTO>
                    .Create()
                    .WithSucceeded(false)
                    .WithMessages(new List<string> { $"No classes found !" })
                    .Build();

            var PaginateInfo = await _services.GetPaginateInfo();

            // Map the list of classes to ClassQueryDTO
            var Page = _mapper.Map<List<ClassQueryDTO>>(classes);

            return PaginatedResult<ClassQueryDTO>
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
