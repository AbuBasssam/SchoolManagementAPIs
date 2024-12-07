using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses
{
    public class GeAvailableEnrollmentCoursesQueryHandler : IRequestHandler<GeAvailableEnrollmentCoursesQuery, Response<IList<AvailableEnrollmentCoursesDTO>>>
    {
        private readonly IEnrollmentServices _services;
        private readonly ResponseHandler _response;

        public GeAvailableEnrollmentCoursesQueryHandler(IEnrollmentServices services, ResponseHandler response)
        {
            _services = services;
            _response = response;
        }



        public async Task<Response<IList<AvailableEnrollmentCoursesDTO>>> Handle(GeAvailableEnrollmentCoursesQuery request, CancellationToken cancellationToken)
        {
            var Courses = await _services.GeAvailableEnrollmentCourses(request.StudentNumber);

            return Courses == null || !Courses.Any() ?
                _response.NotFound<IList<AvailableEnrollmentCoursesDTO>>("No Courses available") : _response.Success(Courses);
        }
    }
}
