using ApplicationLayer.Models;
using DomainLayer.Helper_Classes;
using MediatR;

namespace ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules
{
    public class GetAvailableSchedulesQuery : IRequest<Response<ICollection<WeekSchedule>>>
    {
        #region Field(s)
        public GetAvailableSchedulesQueryDTO DTO { get; set; }

        #endregion

        #region Constructure(s)
        public GetAvailableSchedulesQuery(GetAvailableSchedulesQueryDTO dto)
        {
            DTO = dto;
        }

        #endregion 
    }

















}
