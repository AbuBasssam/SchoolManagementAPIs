using ApplicationLayer.Features.Students.Commands;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Teacher.Commands.ChangePassword
{

    public partial class TeacherChangePasswordCommand : IRequest<Response<bool>>
    {
        public ChangePasswordCommandDTO DTO { get; set; }
        public TeacherChangePasswordCommand(ChangePasswordCommandDTO dto)
        {
            DTO = dto;
        }
    }
}
