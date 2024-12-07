using ApplicationLayer.Features.Courses.Queries.GetCourseByName;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Courses.Queries.GetCoursesByName
{
    public class GetCourseByNameQueryHandler : IRequestHandler<GetCourseByNameQuery, Response<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _services;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion


        #region Constructure(s)
        public GetCourseByNameQueryHandler(ICourseService classServices, ResponseHandler responseHandler)//, IMapper mapper
        {
            // _mapper = mapper;
            _services = classServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<CourseQueryDTO>> Handle(GetCourseByNameQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the Course from the service
            var CDTO = await _services.GetByName(request.CourseName)
                                      .Select(CourseHelper.CourseDTOMap())
                                      .FirstOrDefaultAsync(cancellationToken);


            return CDTO is null ?
                _responseHandler.NotFound<CourseQueryDTO>($"Course with name {request.CourseName} is not found!") : _responseHandler.Success(CDTO);
        }
        #endregion
    }
}
