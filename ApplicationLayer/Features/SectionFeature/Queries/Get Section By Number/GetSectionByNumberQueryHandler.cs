using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Models;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.SectionFeature.Queries
{
    public class GetSectionByNumberQueryHandler : IRequestHandler<GetSectionByNumberQuery, Response<SectionQueryDTO>>
    {

        #region Field(s)
        private readonly ISectionService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetSectionByNumberQueryHandler(ISectionService services, IMapper mapper, ResponseHandler responseHandler)
        {
            _services = services;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<SectionQueryDTO>> Handle(GetSectionByNumberQuery request, CancellationToken cancellationToken)
        {

            var Section = await _services.GetByNumber(request.SectionNumber).AsNoTracking().Select(SectionQueryHelper.SectionDTOMap()).FirstOrDefaultAsync(cancellationToken);

            return Section == null ?
               _responseHandler.NotFound<SectionQueryDTO>($"Section with Number {request.SectionNumber} is not found!") :
               _responseHandler.Success(Section);
        }
        #endregion
    }
}
