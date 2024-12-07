using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Models;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ApplicationLayer.Features.SectionFeature.Commands
{
    public class AddSectionCommandHandler : IRequestHandler<AddSectionCommand, Response<SectionQueryDTO>>
    {
        #region Field(s)
        private readonly ISectionService _SectionService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructor(s)
        public AddSectionCommandHandler(ISectionService SectionService, IMapper mapper, ResponseHandler responseHandler)
        {
            _SectionService = SectionService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<SectionQueryDTO>> Handle(AddSectionCommand request, CancellationToken cancellationToken)
        {
            /* //Old way
             var IsAdded = await _SectionService.AddAsync(_mapper.Map<DomainLayer.Entities.Section>(request.DTO));

            if (IsAdded)
            {
                var Section = await _SectionService.GetByNumber(request.DTO.SectionNumber)
                    .Select(SectionQueryHelper.SectionDTOMap()).SingleAsync();

                return _responseHandler.Created(Section);
            }

            return _responseHandler.BadRequest<SectionQueryDTO>("Add filed");
*/

            var IsAdded = await _SectionService.AddAsync(request.DTO);

            if (IsAdded)
            {
                var Section = await _SectionService.GetByNumber(request.DTO.SectionNumber)
                    .AsNoTracking().Select(SectionQueryHelper.SectionDTOMap()).FirstAsync();

                return _responseHandler.Created(Section);
            }
            return _responseHandler.BadRequest<SectionQueryDTO>("Add filed");

        }
        #endregion
    }
}
