using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Models;
using ApplicationLayer.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.SectionFeature.Commands.AssignSectionTeacher
{
    public class AssignSectionTeacherCommandHandler : IRequestHandler<AssignSectionTeacherCommand, Response<SectionQueryDTO>>
    {
        #region Field(s)
        private readonly ISectionService _service;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)

        public AssignSectionTeacherCommandHandler(ISectionService service, ResponseHandler responseHandler)
        {
            _service = service;
            _responseHandler = responseHandler;
        }

        #endregion

        #region Handler(s)
        public async Task<Response<SectionQueryDTO>> Handle(AssignSectionTeacherCommand request, CancellationToken cancellationToken)
        {
            var IsAdded = await _service.AssignSectionTeacher(request.DTO.SectionNumber, request.DTO.TeacherNumber);
            if (IsAdded)
            {
                var Section = await _service
                    .GetByNumber(request.DTO.SectionNumber)
                    .AsNoTracking()
                    .Select(SectionQueryHelper.SectionDTOMap())
                    .FirstAsync(cancellationToken);

                return _responseHandler.Created(Section);
            }

            return _responseHandler.BadRequest<SectionQueryDTO>("Add field");

        }
        #endregion
    }
}

