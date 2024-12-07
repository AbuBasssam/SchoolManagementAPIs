using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Courses.Commands.Add_Prerequisite_Course
{
    public class AddPrerequisiteCourseCommandHandler : IRequestHandler<AddPrerequisiteCourseCommand, Response<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _CourseService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public AddPrerequisiteCourseCommandHandler(ICourseService CourseService, IMapper mapper, ResponseHandler responseHandler)
        {
            _CourseService = CourseService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<CourseQueryDTO>> Handle(AddPrerequisiteCourseCommand request, CancellationToken cancellationToken)
        {

            var IsAdded = await _CourseService.AddPrerequisiteCourse(request.DTO);

            if (IsAdded)
            {
                var Course = await _CourseService.GetByCode(request.DTO.CourseCode).FirstOrDefaultAsync(cancellationToken);
                return _responseHandler.Success(_mapper.Map<CourseQueryDTO>(Course));

            }
            return _responseHandler.BadRequest<CourseQueryDTO>("Add failed");

        }
        #endregion

    }



}
