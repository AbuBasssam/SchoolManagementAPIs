using ApplicationLayer.Features;
using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Features.User.Queries.Get_User_By_User_Number;
using ApplicationLayer.Features.UserFeature.Commands.AddAdminCommand;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = nameof(enRole.Admin))]
    [ApiController]
    public class UserController : ApiController
    {

        [HttpGet(Router.UserRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]

        public async Task<IActionResult> GetUsersPage(int PageNumber = 1)
        {
            var query = new GetUsersPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }




        [HttpGet(Router.UserRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]

        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetUserByIDQuery(Id);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }




        [HttpGet(Router.UserRouter.ByUserName)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        public async Task<IActionResult> GetByUserName(string UserName)
        {
            var query = new GetUserByUserNameQuery(UserName);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }


        [HttpPost(Router.UserRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.Created)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        public async Task<IActionResult> AddNewAdmin([FromBody] AddAdminDTO DTO)
        {
            var command = new AddUserCommand(DTO);

            var Admin = await Sender.Send(command);

            return NewResult(Admin);

        }
    }

}
