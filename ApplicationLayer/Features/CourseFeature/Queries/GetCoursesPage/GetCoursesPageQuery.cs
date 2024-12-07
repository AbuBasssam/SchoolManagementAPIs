using ApplicationLayer.Comman;
using MediatR;

namespace ApplicationLayer.Features.Courses.Queries.GetCoursesList
{
    public class GetCoursesPageQuery : IRequest<PaginatedResult<CourseQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetCoursesPageQuery(int pageNumber) => PageNumber = pageNumber;

        #endregion
    }
}
