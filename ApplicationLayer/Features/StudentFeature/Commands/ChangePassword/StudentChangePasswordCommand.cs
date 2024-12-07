using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Students.Commands.ChangePassword
{
    public class StudentChangePasswordCommand : IRequest<Response<bool>>
    {
        public ChangePasswordCommandDTO DTO { get; set; }
        public StudentChangePasswordCommand(ChangePasswordCommandDTO dto)
        {
            DTO = dto;
        }
    }

}
