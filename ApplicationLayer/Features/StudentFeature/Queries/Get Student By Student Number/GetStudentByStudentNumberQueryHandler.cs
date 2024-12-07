using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Student.Queries.Get_Student_By_Student_Number
{
    public class GetStudentByStudentNumberQueryHandler : IRequestHandler<GetStudentByStudentNumberQuery, Response<StudentQueryDTO>>
    {

        #region Field(s)
        private readonly IStudentService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetStudentByStudentNumberQueryHandler(IStudentService StudentServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = StudentServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<StudentQueryDTO>> Handle(GetStudentByStudentNumberQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of Student from the service
            var Student = await _services.GetByStudentNumber(request.StudentNumber)
                .Select(StudentQueryHelper.StudentDTOMap()).FirstOrDefaultAsync(cancellationToken);
               
               
                 

            return Student == null ?
               _responseHandler.NotFound<StudentQueryDTO>($"Student with Number {request.StudentNumber} is not found!") :
               _responseHandler.Success(Student);

        }
        #endregion
    }
}
