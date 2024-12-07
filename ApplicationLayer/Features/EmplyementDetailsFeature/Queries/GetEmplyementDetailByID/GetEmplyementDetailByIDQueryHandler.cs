using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByID
{
    public class GetEmplyementDetailByIDQueryHandler : IRequestHandler<GetEmplyementDetailByIDQuery, Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        private readonly IEmploymentDetailsService _Service;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetEmplyementDetailByIDQueryHandler(IEmploymentDetailsService service, ResponseHandler responseHandler)//, IMapper mapper
        {
            _Service = service;
            //_mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<EmplyementDetailQueryDTO>> Handle(GetEmplyementDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var Details = await _Service.GetById(request.ID)
                .Select(EmploymentDetailsQueryHelper.EmploymentDetailsDTOMap())
                .SingleOrDefaultAsync(cancellationToken);

            return Details == null ?
               _responseHandler.NotFound<EmplyementDetailQueryDTO>($"Details with ID {request.ID} is not found!") : _responseHandler.Success(Details);
        }
        #endregion
    }
}