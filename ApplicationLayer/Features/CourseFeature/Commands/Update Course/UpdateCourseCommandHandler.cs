using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Courses.Commands.Update_Course
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Response<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _CourseService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public UpdateCourseCommandHandler(ICourseService CourseService, IMapper mapper, ResponseHandler responseHandler)
        {
            _CourseService = CourseService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<CourseQueryDTO>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {

            var IsUpdateed = await _CourseService.UpdateAsync(request.CourseCode, request.DTO);

            if (IsUpdateed)
            {
                var Course = await _CourseService.GetByCode(request.CourseCode).FirstOrDefaultAsync(cancellationToken);
                return _responseHandler.Success(_mapper.Map<CourseQueryDTO>(Course));

            }
            return _responseHandler.BadRequest<CourseQueryDTO>("Update filed");

        }
        #endregion

    }
}
