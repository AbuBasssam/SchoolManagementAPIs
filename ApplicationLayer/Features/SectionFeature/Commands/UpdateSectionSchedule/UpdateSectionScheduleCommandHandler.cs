using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Models;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.SectionFeature.Commands.UpdateSection
{
    public class UpdateSectionScheduleCommandHandler : IRequestHandler<UpdateSectionScheduleCommand, Response<SectionQueryDTO>>
    {
        #region Field(s)

        private readonly ISectionService _SectionService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructor(s)
        public UpdateSectionScheduleCommandHandler(ISectionService SectionService, IMapper mapper, ResponseHandler responseHandler)
        {
            _SectionService = SectionService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        #endregion

        #region Handler(s)
        public async Task<Response<SectionQueryDTO>> Handle(UpdateSectionScheduleCommand request, CancellationToken cancellationToken)
        {
            var IsUpdateed = await _SectionService.UpdateSectionSchedule(request.DTO);

            if (IsUpdateed)
            {
                var section = await _SectionService
                                   .GetByNumber(request.DTO.SectionNumber)
                                   .AsNoTracking()
                                   .Select(SectionQueryHelper.SectionDTOMap())
                                   .FirstAsync(cancellationToken);

                return _responseHandler.Success(section);
            }
            return _responseHandler.BadRequest<SectionQueryDTO>("Update filed");


            /*old way
              var schedule = _mapper.Map<DomainLayer.Entities.Schedule>(request.DTO.Schedule);

            var IsUpdateed = await _SectionService.UpdateSectionSchedule(request.DTO.SectionNumber, schedule);

            if (IsUpdateed)
            {
                var section =
                    await _SectionService
                    .GetByNumber(request.DTO.SectionNumber)
                    .AsNoTracking()
                    .Select(SectionQueryHelper.SectionDTOMap())
                    .FirstAsync(cancellationToken);

                return _responseHandler.Success(section);

            }

            return _responseHandler.BadRequest<SectionQueryDTO>("Update filed");*/


        }
        #endregion
    }




}