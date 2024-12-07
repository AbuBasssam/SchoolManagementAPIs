using ApplicationLayer.Features;
using ApplicationLayer.Features.Students.Commands;
using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Features.Teacher.Commands.ChangePassword;
using ApplicationLayer.Features.Teacher.Queries;
using ApplicationLayer.Features.Teacher.Queries.Get_Teacher_By_Teacher_Number;
using ApplicationLayer.Features.TeacherFeature.Commands.DeleteTeacherByTeacherNumber;
using ApplicationLayer.Features.Teachers.Commands.AddNewTeacher;
using ApplicationLayer.Features.Teachers.Commands.UpdateTeacher;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.Features.TeacherFeatrue.Commands.DeleteTeacherCommand;

namespace PresentationLayer.Controllers
{
    [ApiController]
    public class TeacherController : ApiController
    {
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpGet(Router.TeacherRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetTeachersPage(int PageNumber = 1)
        {
            var query = new GetTeachersPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }



        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpGet(Router.TeacherRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var query = new GetTeacherByIDQuery(Id);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }



        [Authorize(Roles = $"{nameof(enRole.Teacher)},{nameof(enRole.Admin)}")]
        [HttpGet(Router.TeacherRouter.ByTeacherNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetByTeacherNumber([FromRoute] string TeacherNumber)
        {
            var query = new GetTeacherByTeacherNumberQuery(TeacherNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }



        [Authorize(Roles = nameof(enRole.Admin))]

        [HttpPost(Router.TeacherRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.Created)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> AddNewTeacher([FromBody] AddTeacherDTO SDTO)
        {
            var command = new AddTeacherCommand(SDTO);

            // Send the query using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);

        }



        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpPut(Router.TeacherRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> UpdateTeacherInfo(string TeacherNumber, [FromBody] UpdateInfoDTO DTO)
        {
            var command = new UpdateTeacherInfoCommand(DTO, TeacherNumber);

            // Send the query using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);

        }



        [Authorize(Roles = nameof(enRole.Teacher))]

        [HttpPut(Router.TeacherRouter.ChangePassword)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> ChangePassword(string TeacherNumber, string CurrentPassword, string NewPassword)
        {
            ChangePasswordCommandDTO DTO = new ChangePasswordCommandDTO(TeacherNumber, CurrentPassword, NewPassword);

            var command = new TeacherChangePasswordCommand(DTO);

            // Send the query using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);

        }


        // DELETE api/<TeacherController>/{id}
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpDelete(Router.TeacherRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await Sender.Send(new DeleteTeacherByIdCommand(Id));
            return NewResult(response);
        }

        // DELETE api/<TeacherController>/{id}
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpDelete(Router.TeacherRouter.ByTeacherNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> Delete([FromRoute] string TeacherNumber)
        {
            var response = await Sender.Send(new DeleteTeacherByTeacherNumberCommand(TeacherNumber));

            return NewResult(response);
        }
    }
}
