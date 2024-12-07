using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.EnrollmentFeature.Commands.DeleteEnrollment
{
    public partial class DeleteEnrollmentCommand
    {
        public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, Response<string>>
        {
            #region Field(s)
            private readonly IEnrollmentServices _service;
            private readonly IMapper _mapper;
            private readonly ResponseHandler _responseHandler;
            #endregion

            #region Constructor(s)
            public DeleteEnrollmentCommandHandler(IEnrollmentServices service, IMapper mapper, ResponseHandler responseHandler)
            {
                _service = service;
                _mapper = mapper;
                _responseHandler = responseHandler;
            }
            #endregion

            #region Handler(s)
            public async Task<Response<string>> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
            {
                var student = await _service.GetEnrollment(request.StudentNumber, request.SectionNumber).FirstOrDefaultAsync();
                if (student == null) return _responseHandler.NotFound<string>($"No Enrollment found for {request.StudentNumber} in Section {request.SectionNumber}");

                bool isDeleted = await _service.DeleteAsync(student);

                return isDeleted ? _responseHandler.Deleted<string>("Deleted successfully") : _responseHandler.BadRequest<string>("Failed to delete");
            }
            #endregion
        }

    }
}
