using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Students.Commands.AddNewStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Response<StudentQueryDTO>>
    {
        #region Field(s)
        private readonly IStudentService _StudentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public AddStudentCommandHandler(IStudentService StudentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _StudentService = StudentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<StudentQueryDTO>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {

            var IsAdded = await _StudentService.AddAsync(request.DTO);

            if (IsAdded)
            {
                var Student = await _StudentService.GetByNationalNO(request.DTO.InfoDTO.NationalNO)
                    .Select(StudentQueryHelper.StudentDTOMap()).FirstAsync();

                return _responseHandler.Created(Student);
            }

            return _responseHandler.BadRequest<StudentQueryDTO>("Add filed");


        }
        #endregion
    }


}
