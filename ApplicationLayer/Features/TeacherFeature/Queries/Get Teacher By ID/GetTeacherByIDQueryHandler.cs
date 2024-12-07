using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Teacher.Queries
{
    public class GetTeacherByIDQueryHandler : IRequestHandler<GetTeacherByIDQuery, Response<TeacherQueryDTO>>
    {
        #region Fields
        private readonly ITeacherService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetTeacherByIDQueryHandler(ITeacherService TeacherServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = TeacherServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<TeacherQueryDTO>> Handle(GetTeacherByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of Teacher from the service
            var Teacher = await _services.GetById(request.ID).Select(TeacherQueryHelper.TeacherDTOMap())
                .SingleOrDefaultAsync(cancellationToken);

            return Teacher == null ?
               _responseHandler.NotFound<TeacherQueryDTO>($"Teacher with ID {request.ID} is not found!") :
               _responseHandler.Success(Teacher);

        }
        #endregion
    }

}
