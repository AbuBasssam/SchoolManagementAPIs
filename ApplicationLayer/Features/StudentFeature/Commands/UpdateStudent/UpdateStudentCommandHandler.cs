using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentInfoCommand, Response<StudentQueryDTO>>
    {

        #region Field(s)
        private readonly IStudentService _StudentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public UpdateStudentCommandHandler(IStudentService StudentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _StudentService = StudentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<StudentQueryDTO>> Handle(UpdateStudentInfoCommand request, CancellationToken cancellationToken)
        {
            //var StudentEntity = await _StudentService.GetByStudentNumber(request.StudentNumber).FirstAsync();

            //_mapper.Map(request.DTO, StudentEntity.UserInfo.PersonInfo);

            var IsUpdated = await _StudentService.UpdateStudentInfoAsync(request.StudentNumber, request.DTO);

            if (IsUpdated)
            {
                var Student = await _StudentService.GetByStudentNumber(request.StudentNumber)
                    .Select(StudentQueryHelper.StudentDTOMap()).SingleAsync();

                return _responseHandler.Success(Student);
            }

            return _responseHandler.BadRequest<StudentQueryDTO>("Update filed");

        }

        #endregion

    }
}
