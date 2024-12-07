using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Queries.GetCourseByCode
{
    public class GetCourseByCodeQuery : IRequest<Response<CourseQueryDTO>>
    {
        #region Field(s)
        public string CourseCode { get; set; }

        #endregion

        #region Constructure(s)
        public GetCourseByCodeQuery(string courseCode) => CourseCode = courseCode;
        #endregion

    }

}
