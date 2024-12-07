using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Models;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.SectionFeature.Queries.GetSectionByID
{
    public class GetSectionByIDQueryHandler : IRequestHandler<GetSectionByIDQuery, Response<SectionQueryDTO>>
    {

        #region Field(s)
        private readonly ISectionService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetSectionByIDQueryHandler(ISectionService services, IMapper mapper, ResponseHandler responseHandler)
        {
            _services = services;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<SectionQueryDTO>> Handle(GetSectionByIDQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var Section = await _services.GetById(request.ID).AsNoTracking()
                .Select(SectionQueryHelper.SectionDTOMap()).SingleOrDefaultAsync(cancellationToken);

            return Section == null ?
               _responseHandler.NotFound<SectionQueryDTO>($"Section with ID {request.ID} is not found!") :
               _responseHandler.Success(Section);
        }
        #endregion
    }

}
