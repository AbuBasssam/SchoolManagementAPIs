using ApplicationLayer.Comman;
using ApplicationLayer.Features.Teacher.Queries;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features
{
    public class GetTeachersPageQueryHandler : IRequestHandler<GetTeachersPageQuery, PaginatedResult<TeacherQueryDTO>>
    {
        #region Field(s)
        private readonly ITeacherService _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetTeachersPageQueryHandler(ITeacherService Services, IMapper mapper)
        {
            _mapper = mapper;
            _services = Services;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<TeacherQueryDTO>> Handle(GetTeachersPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of Teacher from the service
            var Page = await _services.GetTeacherPage(request.PageNumber).Select(TeacherQueryHelper.TeacherDTOMap()).ToListAsync(cancellationToken);

            //Checking
            if (Page == null || !Page.Any())
                return PaginatedResult<TeacherQueryDTO>
                   .Create()
                   .WithSucceeded(false)
                   .WithMessages(new List<string> { $"No Teacher found!" })
                   .Build();

            var PaginateInfo = await _services.GetPaginateInfo();


            


            return PaginatedResult<TeacherQueryDTO>
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
