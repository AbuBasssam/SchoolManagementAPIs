using ApplicationLayer.Features.Teacher.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Teachers.Commands.AddNewTeacher
{
    public class AddTeacherCommand : IRequest<Response<TeacherQueryDTO>>
    {
        #region Field(s)
        public AddTeacherDTO Teacher { get; set; }
        #endregion

        #region Constructure(s)
        public AddTeacherCommand(AddTeacherDTO dto)
        {
            Teacher = dto;
        }
        #endregion

    }


}
