using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Schedule.Queries.GetScheduleByID
{
    public class GetScheduleByIDQueryHandler : IRequestHandler<GetScheduleByIDQuery, Response<ScheduleDTO>>
    {
        #region Field(s)
        private readonly IScheduleService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetScheduleByIDQueryHandler(IScheduleService ScheduleServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = ScheduleServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<ScheduleDTO>> Handle(GetScheduleByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the Schedule from the service

            var Schedule = await _services.GetById(request.ID).SingleOrDefaultAsync(cancellationToken);

            return Schedule == null ?
               _responseHandler.NotFound<ScheduleDTO>($"Schedule with ID {request.ID} is not found!") :
               _responseHandler.Success(_mapper.Map<ScheduleDTO>(Schedule));

        }
        #endregion
    }

}
