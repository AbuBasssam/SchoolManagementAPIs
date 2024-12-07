using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Students.Commands.ChangePassword
{
    public class StudentChangePasswordCommandHandler : IRequestHandler<StudentChangePasswordCommand, Response<bool>>
    {
        private readonly IStudentService _service;
        private readonly ResponseHandler _responseHandler;

        public StudentChangePasswordCommandHandler(IStudentService service, ResponseHandler responseHandler)
        {
            _service = service;
            _responseHandler = responseHandler;
        }

        public async Task<Response<bool>> Handle(StudentChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var IsUpdated = await _service.ChangePasswordAsync(request.DTO.UserName, request.DTO.CurrentPassword, request.DTO.NewPassword);

            return IsUpdated ? _responseHandler.Success(IsUpdated) : _responseHandler.BadRequest<bool>("Update Field");
        }
    }
}
