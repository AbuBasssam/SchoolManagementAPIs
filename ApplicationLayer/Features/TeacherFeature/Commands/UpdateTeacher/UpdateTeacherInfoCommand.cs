using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Features.Teacher.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherInfoCommand : IRequest<Response<TeacherQueryDTO>>
    {
        public UpdateInfoDTO DTO { get; set; }
        public string TeacherNumber { get; set; }
        public UpdateTeacherInfoCommand(UpdateInfoDTO dto, string teacherNumber)
        {
            DTO = dto;
            TeacherNumber = teacherNumber;
        }

    }
}
