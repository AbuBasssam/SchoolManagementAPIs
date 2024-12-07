using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Commands.Add_Prerequisite_Course
{
    public class AddPrerequisiteCourseCommand : IRequest<Response<CourseQueryDTO>>
    {
        #region Field(s)

        public PrerequisiteCourseCommandDTO DTO { get; set; }

        #endregion

        #region Constructure(s)

        public AddPrerequisiteCourseCommand(PrerequisiteCourseCommandDTO dto) => DTO = dto;

        #endregion

    }



}
