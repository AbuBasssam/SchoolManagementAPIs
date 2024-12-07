using ApplicationLayer.Features.Teacher.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Teachers.Commands.AddNewTeacher
{
    public class AddTeacherCommandHandler : IRequestHandler<AddTeacherCommand, Response<TeacherQueryDTO>>
    {
        #region Field(s)
        private readonly ITeacherService _TeacherService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public AddTeacherCommandHandler(ITeacherService TeacherService, IMapper mapper, ResponseHandler responseHandler)
        {
            _TeacherService = TeacherService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<TeacherQueryDTO>> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {

            var IsAdded = await _TeacherService.AddAsync(request.Teacher);

            if (IsAdded)
            {
                var Teacher = await _TeacherService.GetByNationalNO(request.Teacher.InfoDTO.NationalNO)
                    .Select(TeacherQueryHelper.TeacherDTOMap()).SingleAsync();

                return _responseHandler.Created(Teacher);
            }

            return _responseHandler.BadRequest<TeacherQueryDTO>("Add filed");


        }
        #endregion
    }


}
