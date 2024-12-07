using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Queries.GetCourseByID
{

    public class GetCourseByIDQuery : IRequest<Response<CourseQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Consstructure(s)
        public GetCourseByIDQuery(int Id) => ID = Id;
        #endregion

    }


}
