using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Teacher.Commands.ChangePassword
{
    public class TeacherChangePasswordCommandHandler : IRequestHandler<TeacherChangePasswordCommand, Response<bool>>
    {
        private readonly ITeacherService _service;
        private readonly ResponseHandler _responseHandler;

        public TeacherChangePasswordCommandHandler(ITeacherService service, ResponseHandler responseHandler)
        {
            _service = service;
            _responseHandler = responseHandler;
        }

        public async Task<Response<bool>> Handle(TeacherChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var IsUpdated = await _service.ChangePasswordAsync(request.DTO.UserName, request.DTO.CurrentPassword, request.DTO.NewPassword);

            return IsUpdated ? _responseHandler.Success(IsUpdated) : _responseHandler.BadRequest<bool>("UpdateField");
        }
    }

}

