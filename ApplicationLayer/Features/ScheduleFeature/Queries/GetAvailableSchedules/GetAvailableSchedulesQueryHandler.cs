using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Helper_Classes;
using MediatR;

namespace ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules
{
    public class GetAvailableSchedulesQueryHandler : IRequestHandler<GetAvailableSchedulesQuery, Response<ICollection<WeekSchedule>>>
    {
        #region Field(s)
        private readonly IScheduleService _service;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructure(s)
        public GetAvailableSchedulesQueryHandler(IScheduleService service, ResponseHandler responseHandler)
        {
            _service = service;
            _responseHandler = responseHandler;

        }

        public async Task<Response<ICollection<WeekSchedule>>> Handle(GetAvailableSchedulesQuery request, CancellationToken cancellationToken)
        {
            var Schedules = await _service.GetAvailableSchedules(request.DTO);



            if (Schedules.ToHashSet() == null || !Schedules.Any())
                return _responseHandler.BadRequest<ICollection<WeekSchedule>>("No Schedules Available !");

            return _responseHandler.Success(Schedules);
        }

        #endregion
    }

















}
