using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Commands
{
    public class AddCourseCommand : IRequest<Response<CourseQueryDTO>>
    {
        #region Field(s)
        public AddCourseCommandDTO DTO { get; set; }

        #endregion

        #region Constructure(s)

        public AddCourseCommand(AddCourseCommandDTO dto) => DTO = dto;

        #endregion

    }


}
