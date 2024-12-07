using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.StudentFeature.Commands.DeleteStudentByStudentNumber
{
    public class DeleteTeacherByTeacherNumberCommandHandler : IRequestHandler<DeleteStudentByStudentNumberCommand, Response<string>>
    {
        #region Field(s)
        private readonly IStudentService _service;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public DeleteTeacherByTeacherNumberCommandHandler(IStudentService service, IMapper mapper, ResponseHandler responseHandler)
        {
            _service = service;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<string>> Handle(DeleteStudentByStudentNumberCommand request, CancellationToken cancellationToken)
        {
            var student = await _service.GetByStudentNumber(request.StudentNumber).FirstOrDefaultAsync();

            if (student == null) return _responseHandler.NotFound<string>($"No student found with number:{request.StudentNumber}");

            bool isDeleted = await _service.DeleteAsync(student);

            return isDeleted ? _responseHandler.Deleted<string>("Deleted successfully") : _responseHandler.BadRequest<string>("Failed to delete");
        }
        #endregion
    }
}
