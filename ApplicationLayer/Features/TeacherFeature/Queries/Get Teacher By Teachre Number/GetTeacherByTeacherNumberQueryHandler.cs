using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Teacher.Queries.Get_Teacher_By_Teacher_Number
{
    public class GetTeacherByTeacherNumberQueryHandler : IRequestHandler<GetTeacherByTeacherNumberQuery, Response<TeacherQueryDTO>>
    {

        #region Field(s)
        private readonly ITeacherService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetTeacherByTeacherNumberQueryHandler(ITeacherService TeacherServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = TeacherServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<TeacherQueryDTO>> Handle(GetTeacherByTeacherNumberQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of Teacher from the service
            var Teacher = await _services.GetByTeacherNumber(request.TeacherNumber)
                .Select(TeacherQueryHelper.TeacherDTOMap()).FirstOrDefaultAsync(cancellationToken);
               
               
                 

            return Teacher == null ?
               _responseHandler.NotFound<TeacherQueryDTO>($"Teacher with Number {request.TeacherNumber} is not found!") :
               _responseHandler.Success(Teacher);

        }
        #endregion
    }
}
