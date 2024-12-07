using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment
{
    public class AddNewEnrollmentCommand : IRequest<Response<bool>>
    {
        public AddNewEnrollmentCommandDTO DTO { get; set; }

        public AddNewEnrollmentCommand(AddNewEnrollmentCommandDTO dTO)
        {
            DTO = dTO;
        }
    }
}
