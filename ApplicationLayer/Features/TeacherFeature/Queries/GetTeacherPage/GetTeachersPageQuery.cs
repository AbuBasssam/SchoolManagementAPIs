using ApplicationLayer.Comman;
using ApplicationLayer.Features.Teacher.Queries;
using MediatR;

namespace ApplicationLayer.Features
{
    public class GetTeachersPageQuery : IRequest<PaginatedResult<TeacherQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetTeachersPageQuery(int pageNumber)
        {
            PageNumber = pageNumber;
        }

        #endregion
    }

}
