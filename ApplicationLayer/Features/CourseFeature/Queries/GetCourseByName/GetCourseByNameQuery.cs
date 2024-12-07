using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Queries.GetCourseByName
{
    public class GetCourseByNameQuery : IRequest<Response<CourseQueryDTO>>
    {
        #region Filed(s)
        public string CourseName { get; set; }

        #endregion

        #region Constructure(s)
        public GetCourseByNameQuery(string courseName) => CourseName = courseName;
        #endregion

    }
}



