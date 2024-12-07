using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Student.Queries
{
    public class GetStudentByIDQueryHandler : IRequestHandler<GetStudentByIDQuery, Response<StudentQueryDTO>>
    {

        #region Field(s)
        private readonly IStudentService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetStudentByIDQueryHandler(IStudentService StudentServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = StudentServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<StudentQueryDTO>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of Student from the service
            var Student =await  _services.GetById(request.ID)
                .Select(StudentQueryHelper.StudentDTOMap()).FirstOrDefaultAsync(cancellationToken);
            

            return Student == null ?
               _responseHandler.NotFound<StudentQueryDTO>($"Student with ID {request.ID} is not found!") :
               _responseHandler.Success(Student);

        }
        #endregion
    }
}
