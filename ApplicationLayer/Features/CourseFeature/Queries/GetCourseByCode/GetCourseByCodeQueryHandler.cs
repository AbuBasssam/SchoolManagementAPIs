using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Courses.Queries.GetCourseByCode
{
    public class GetCourseByCodeQueryHandler : IRequestHandler<GetCourseByCodeQuery, Response<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _services;
        // private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetCourseByCodeQueryHandler(ICourseService CourseServices, ResponseHandler responseHandler) //, IMapper mapper
        {
            // _mapper = mapper;
            _services = CourseServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<CourseQueryDTO>> Handle(GetCourseByCodeQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the Course from the service
            var CDTO = await _services.GetByCode(request.CourseCode).Select(CourseHelper.CourseDTOMap()).FirstOrDefaultAsync();

            return CDTO is null ?
                _responseHandler.NotFound<CourseQueryDTO>($"Course with code {request.CourseCode} is not found!") : _responseHandler.Success(CDTO);
        }
        #endregion
    }

}
