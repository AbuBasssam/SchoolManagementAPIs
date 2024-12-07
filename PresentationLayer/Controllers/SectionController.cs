using ApplicationLayer.Features.Schedule.Queries;
using ApplicationLayer.Features.SectionFeature.Commands;
using ApplicationLayer.Features.SectionFeature.Commands.AssignSectionTeacher;
using ApplicationLayer.Features.SectionFeature.Commands.CloseSection;
using ApplicationLayer.Features.SectionFeature.Commands.UpdateSection;
using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Features.SectionFeature.Queries.GetSectionByID;
using ApplicationLayer.Features.SectionFeature.Queries.GetSectionsPage;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Authorize(Roles = nameof(enRole.Admin))]

    public class SectionController : ApiController
    {

        [HttpGet(Router.SectionRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> GetSectionsPage(int PageNumber = 1)
        {
            var query = new GetSectionsPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }






        [HttpGet(Router.SectionRouter.BySectionNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> GetSectionByNumber([FromRoute] string SectionNumber)
        {
            var query = new GetSectionByNumberQuery(SectionNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }



        [HttpGet(Router.SectionRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetSectionById([FromRoute] int Id)
        {
            var query = new GetSectionByIDQuery(Id);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            //Return the result
            return NewResult(response);
        }



        [HttpPost(Router.SectionRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.Created)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> AddNewSection([FromBody] AddSectionCommandDTO SDTO)
        {
            var command = new AddSectionCommand(SDTO);


            var response = await Sender.Send(command);

            return NewResult(response);

        }



        [HttpPost(Router.SectionRouter.AssignSectionTeacher)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> AssignSectionTeacher(string SectionNumber, string TeacherNumber)
        {
            AssignSectionTeacherCommandDTO DTO = new AssignSectionTeacherCommandDTO(SectionNumber, TeacherNumber);

            var command = new AssignSectionTeacherCommand(DTO);

            // Send the query using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);


        }



        [HttpPut(Router.SectionRouter.UpdateSchedule)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> UpdateSectionSchedule([FromRoute] string sectionNumber, [FromBody] ScheduleDTO DTO)
        {
            UpdateSectionCommandDTO SDTO = new UpdateSectionCommandDTO(sectionNumber, DTO);

            var command = new UpdateSectionScheduleCommand(SDTO);

            // Send the command using MediatR

            var response = await Sender.Send(command);

            //Return the result

            return NewResult(response);

        }



        [HttpDelete(Router.SectionRouter.BySectionNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> DeleteSection([FromRoute] string SectionNumber)
        {
            var command = new DeleteSectionCommand(SectionNumber);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            //Return the result
            return NewResult(response);

        }






    }

}
