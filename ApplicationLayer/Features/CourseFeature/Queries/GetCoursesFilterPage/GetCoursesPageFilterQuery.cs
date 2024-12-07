using ApplicationLayer.Comman;
using MediatR;

namespace ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage
{
    public class GetCoursesPageFilterQuery : IRequest<PaginatedResult<CourseQueryDTO>>
    {

        #region Field(s)
        public CourseFilter Filter { get; set; }
        public FilterInfo FilterInfo { get; set; }

        #endregion

        #region Constructure(s)
        public GetCoursesPageFilterQuery(CourseFilter filter, FilterInfo filterInfo)
        {
            Filter = filter;
            FilterInfo = filterInfo;

        }
        #endregion
    }
}
