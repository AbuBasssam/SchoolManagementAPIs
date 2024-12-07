using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.EnrollmentFeature.Commands.DeleteEnrollment
{
    public partial class DeleteEnrollmentCommand : IRequest<Response<string>>
    {
        public string StudentNumber { get; set; }
        public string SectionNumber { get; set; }

        public DeleteEnrollmentCommand(string studentNumber, string sectionNumbe)
        {
            StudentNumber = studentNumber;
            SectionNumber = sectionNumbe;
        }

    }
}
