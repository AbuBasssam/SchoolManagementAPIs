using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment
{

    public class AddNewEnrollmentCommandHandler : IRequestHandler<AddNewEnrollmentCommand, Response<bool>>
    {
        private readonly IEnrollmentServices _services;
        private readonly ResponseHandler _response;

        public AddNewEnrollmentCommandHandler(IEnrollmentServices services, ResponseHandler response)
        {
            _services = services;
            _response = response;
        }

        public async Task<Response<bool>> Handle(AddNewEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var IsAdded = await _services.AddNewEnrollmentAsync(request.DTO);


            return IsAdded ? _response.Success(IsAdded) : _response.BadRequest<bool>("Add Failed");
        }
    }
}
