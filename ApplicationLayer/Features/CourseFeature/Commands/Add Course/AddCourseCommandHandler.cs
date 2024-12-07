using ApplicationLayer.Features.Courses.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.Features.Courses.Commands
{
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, Response<CourseQueryDTO>>
    {
        #region Field(s)
        private readonly ICourseService _service;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public AddCourseCommandHandler(ICourseService Service, IMapper mapper, ResponseHandler responseHandler)
        {
            _service = Service;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<CourseQueryDTO>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var IsAdded = await _service.AddAsync(request.DTO);

            return IsAdded ?
                _responseHandler.Created(_mapper.Map<CourseQueryDTO>(request.DTO)) : _responseHandler.BadRequest<CourseQueryDTO>("Add failed");

        }

        #endregion
    }

}
