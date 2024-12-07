using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses
{
    public class GeAvailableEnrollmentCoursesQuery : IRequest<Response<IList<AvailableEnrollmentCoursesDTO>>>
    {
        public string StudentNumber { get; set; }

        public GeAvailableEnrollmentCoursesQuery(string studentNumber)
        {
            StudentNumber = studentNumber;
        }

    }
}
