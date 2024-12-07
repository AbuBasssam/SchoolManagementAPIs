using ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByID;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByTeacherNumber
{
    public class GetEmplyementDetailByTeacherNumberQueryHandler : IRequestHandler<GetEmplyementDetailByTeacherNumberQuery, Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        private readonly IEmploymentDetailsService _Service;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)

        public GetEmplyementDetailByTeacherNumberQueryHandler(IEmploymentDetailsService service, ResponseHandler responseHandler)//, IMapper mapper
        {
            _Service = service;
            // _mapper = mapper;
            _responseHandler = responseHandler;
        }

        #endregion

        #region Handler(s)
        public async Task<Response<EmplyementDetailQueryDTO>> Handle(GetEmplyementDetailByTeacherNumberQuery request, CancellationToken cancellationToken)
        {
            var Details = await _Service.GetByTeacherNumber(request.TeacherNumber)
                .Select(EmploymentDetailsQueryHelper.EmploymentDetailsDTOMap())
                .FirstOrDefaultAsync(cancellationToken);

            return Details == null ?
               _responseHandler.NotFound<EmplyementDetailQueryDTO>($"No details for Teacher number {request.TeacherNumber} not found !") : _responseHandler.Success(Details);
        }

        #endregion
    }





}