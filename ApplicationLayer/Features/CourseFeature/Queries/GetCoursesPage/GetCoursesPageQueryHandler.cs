using ApplicationLayer.Comman;
using ApplicationLayer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Courses.Queries.GetCoursesList
{
    public class GetCoursesPageQueryHandler : IRequestHandler<GetCoursesPageQuery, PaginatedResult<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _services;
        // private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetCoursesPageQueryHandler(ICourseService Services)//, IMapper mapper
        {
            //_mapper = mapper;
            _services = Services;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<CourseQueryDTO>> Handle(GetCoursesPageQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of courses from the service
            var Page = await _services.GetCoursesPage(request.PageNumber)
                .Select(CourseHelper.CourseDTOMap())
                .ToListAsync(cancellationToken);

            //Checking
            if (Page == null || !Page.Any())
                return PaginatedResult<CourseQueryDTO>.Create().WithSucceeded(false).WithMessages(new List<string> { $"No courses found!" }).Build();


            var PaginateInfo = await _services.GetPaginateInfo();


            return PaginatedResult<CourseQueryDTO>.Create()
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
