using ApplicationLayer.Comman;
using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationLayer.Features
{
    public class GetStudentsPageQueryHandler : IRequestHandler<GetStudentsPageQuery, PaginatedResult<StudentQueryDTO>>
    {
        #region Field(s)
        private readonly IStudentService _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetStudentsPageQueryHandler(IStudentService classServices, IMapper mapper)
        {
            _mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<StudentQueryDTO>> Handle(GetStudentsPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of Students from the service
            var Page = await _services.GetStudentsPage(request.PageNumber).Select(StudentQueryHelper.StudentDTOMap()).ToListAsync(cancellationToken);

            //Checking
            if (Page == null || !Page.Any())
                return PaginatedResult<StudentQueryDTO>
                   .Create()
                   .WithSucceeded(false)
                   .WithMessages(new List<string> { $"No Students found!" })
                   .Build();

            var PaginateInfo = await _services.GetPaginateInfo();


            // Map the list of Students to StudentQueryDTO

            // var Page = _mapper.Map<List<StudentQueryDTO>>(students);


            return PaginatedResult<StudentQueryDTO>
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
