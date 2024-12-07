using ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails;
using ApplicationLayer.Features.EmplyementDetails.Queries;
using ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByID;
using ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByTeacherNumber;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = nameof(enRole.Admin))]
    [ApiController]
    public class EmployementDetailController : ApiController
    {

        [HttpGet(Router.EmplymentDetailsRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        public async Task<IActionResult> GetEmplyementDetailPage(int PageNumber = 1)
        {
            var query = new GetEmplyementDetailsPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            //Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);

        }




        [HttpGet(Router.EmplymentDetailsRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]

        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var query = new GetEmplyementDetailByIDQuery(Id);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            //Return the result
            return NewResult(response);
        }





        [HttpGet(Router.EmplymentDetailsRouter.ByTeacherNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]

        public async Task<IActionResult> GetEmplyementDetailByTeacherNumber([FromRoute] string TeacherNumber)
        {

            var query = new GetEmplyementDetailByTeacherNumberQuery(TeacherNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }




        [HttpPut(Router.EmplymentDetailsRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]


        public async Task<IActionResult> UpdateEmplyementDetail(string TeacherNumber, [FromBody] UpdateEmployementDetailsCommandDTO DTO)
        {
            //Set DTO Info
            var command = new UpdateEmplyementDetailCommand(DTO, TeacherNumber);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            //Return the result
            return NewResult(response);

        }



        /* Add EndPoint
        [HttpPost(Router.EmplymentDetailsRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.Created)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        public async Task<IActionResult> AddNewEmplyementDetail([FromBody] AddEmplyementDetailCommandDTO DTO)
        {
            var command = new AddEmployeeDetailCommand(DTO);

            var response = await Sender.Send(command);

            return NewResult(response);

        }*/

    }
}
