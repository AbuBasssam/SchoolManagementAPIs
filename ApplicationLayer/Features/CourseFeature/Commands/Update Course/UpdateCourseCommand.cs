using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Courses.Commands.Update_Course
{

    public class UpdateCourseCommand : IRequest<Response<CourseQueryDTO>>
    {
        #region Fields
        public string CourseCode { get; set; }

        public UpdateCourseCommandDTO DTO { get; set; }

        #endregion

        #region Constructure(s)
        public UpdateCourseCommand(string courseCode, UpdateCourseCommandDTO course)
        {
            CourseCode = courseCode;
            DTO = course;
        }
        #endregion

    }
}
