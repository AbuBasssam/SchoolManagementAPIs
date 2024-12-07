using ApplicationLayer.Features.Teacher.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherInfoCommand, Response<TeacherQueryDTO>>
    {

        #region Field(s)
        private readonly ITeacherService _TeacherService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public UpdateTeacherCommandHandler(ITeacherService TeacherService, IMapper mapper, ResponseHandler responseHandler)
        {
            _TeacherService = TeacherService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<TeacherQueryDTO>> Handle(UpdateTeacherInfoCommand request, CancellationToken cancellationToken)
        {
            //var TeacherEntity = await _TeacherService.GetByTeacherNumber(request.TeacherNumber).FirstAsync();

            //_mapper.Map(request.DTO, TeacherEntity.UserInfo.PersonInfo);

            var IsUpdated = await _TeacherService.UpdateTeacherInfoAsync(request.TeacherNumber, request.DTO);

            if (IsUpdated)
            {
                var Teacher = await _TeacherService.GetByTeacherNumber(request.TeacherNumber)
                    .Select(TeacherQueryHelper.TeacherDTOMap()).FirstAsync();

                return _responseHandler.Success(Teacher);
            }

            return _responseHandler.BadRequest<TeacherQueryDTO>("Update filed");


        }
        #endregion
    }
}
