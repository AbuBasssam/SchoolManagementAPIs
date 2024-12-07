using ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules;
using ApplicationLayer.Features.Schedule.Queries.GetSchedulesPage;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using DomainLayer.Helper_Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    public class ScheduleController : ApiController
    {
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpGet(Router.ScheduleRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]

        public async Task<IActionResult> GetSchedulesPage(int PageNumber = 1)
        {
            var query = new GetSchedulesPageQuery(PageNumber);

            // Send the query using MediatR
            var Schedules = await Sender.Send(query);


            // Return the result
            return Schedules.Succeeded ? Ok(Schedules) : NotFound(Schedules);
        }


        [Authorize(Roles = $"{nameof(enRole.Student)},{nameof(enRole.Admin)}")]

        [HttpGet(Router.ScheduleRouter.AvailableSchedules)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        public async Task<IActionResult> GetAvailableSchedules(string ClassName, TimeSpan StartTime, TimeSpan EndTime, byte TimesPerWeek)
        {
            GetAvailableSchedulesQueryDTO DTO = new GetAvailableSchedulesQueryDTO(ClassName, TimesPerWeek, new TimeSlot { StartTime = StartTime, EndTime = EndTime });

            var query = new GetAvailableSchedulesQuery(DTO);

            // Send the query using MediatR
            var Schedules = await Sender.Send(query);

            // Return the result
            return NewResult(Schedules);
        }
    }
}
