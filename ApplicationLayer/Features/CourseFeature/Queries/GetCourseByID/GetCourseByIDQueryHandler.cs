using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Courses.Queries.GetCourseByID
{
    public class GetCourseByIDQueryHandler : IRequestHandler<GetCourseByIDQuery, Response<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _services;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructure(s)
        public GetCourseByIDQueryHandler(ICourseService CourseServices, ResponseHandler responseHandler)//, IMapper mapper
        {
            //_mapper = mapper;
            _services = CourseServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<CourseQueryDTO>> Handle(GetCourseByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the Course from the service
            var Course = await _services.GetById(request.ID)
                .Select(CourseHelper.CourseDTOMap())
                .FirstOrDefaultAsync(cancellationToken);

            return Course is null ?
                _responseHandler.NotFound<CourseQueryDTO>($"Course with ID {request.ID} is not found!") : _responseHandler.Success(Course);

        }
        #endregion
    }



}
