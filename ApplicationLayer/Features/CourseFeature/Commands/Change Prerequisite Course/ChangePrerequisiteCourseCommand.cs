using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Commands.Update_Course
{

    public class ChangePrerequisiteCourseCommand : IRequest<Response<CourseQueryDTO>>
    {
        #region Fields
        public PrerequisiteCourseCommandDTO DTO { get; set; }

        #endregion

        #region Constructure(s)
        public ChangePrerequisiteCourseCommand(PrerequisiteCourseCommandDTO dto) => DTO = dto;
        #endregion

    }
}
