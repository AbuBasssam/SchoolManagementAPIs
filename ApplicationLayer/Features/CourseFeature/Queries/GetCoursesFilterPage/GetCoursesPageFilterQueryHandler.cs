using ApplicationLayer.Comman;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage
{
    public class GetCoursesPageFilterQueryHandler : IRequestHandler<GetCoursesPageFilterQuery, PaginatedResult<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructure(s)

        public GetCoursesPageFilterQueryHandler(ICourseService classServices, IMapper mapper)
        {
            _mapper = mapper;
            _services = classServices;
        }

        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<CourseQueryDTO>> Handle(GetCoursesPageFilterQuery request, CancellationToken cancellationToken)
        {
            // Fetch the list of courses from the service
            var Courses = await _services.GetCoursesFilterPage(request.Filter, request.FilterInfo);

            //Checking
            if (Courses.Courses == null || !Courses.Courses.Any())

                return PaginatedResult<CourseQueryDTO>.Create().WithSucceeded(false).WithMessages(new List<string> { $"No courses found!" }).Build();


            // Map the list of courses to CourseQueryDTO

            var Page = Courses.Courses.AsQueryable().Select(CourseHelper.CourseDTOMap()).ToList();


            return PaginatedResult<CourseQueryDTO>.Create()
                .WithSucceeded(true)
                .WithData(Page)
                .WithTotaCount(Courses.TotalCount)
                .WithCurrentPage(request.FilterInfo.PageNumber)
                .WithTotalPages(Courses.PageCount)
                .WithPageSize(Page.Count)
                .Build();
        }
        #endregion
    }
}
