using ApplicationLayer.Features;
using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Features.Student.Queries.Get_Student_By_Student_Number;
using ApplicationLayer.Features.StudentFeature.Commands.DeleteStudentByStudentNumber;
using ApplicationLayer.Features.Students.Commands;
using ApplicationLayer.Features.Students.Commands.AddNewStudent;
using ApplicationLayer.Features.Students.Commands.ChangePassword;
using ApplicationLayer.Features.Students.Commands.UpdateStudent;
using ApplicationLayer.Features.Students.Helper;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.Features.StudentFeatrue.Commands.DeleteStudentCommand;

namespace PresentationLayer.Controllers
{
    [ApiController]
    public class StudentController : ApiController
    {
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpGet(Router.StudentRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetStudentsPage(int PageNumber = 1)
        {
            var query = new GetStudentsPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }



        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpGet(Router.StudentRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var query = new GetStudentByIDQuery(Id);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }



        [Authorize(Roles = $"{nameof(enRole.Student)},{nameof(enRole.Admin)}")]
        [HttpGet(Router.StudentRouter.ByStudentNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetByStudentNumber([FromRoute] string StudentNumber)
        {
            var query = new GetStudentByStudentNumberQuery(StudentNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }



        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpPost(Router.StudentRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.Created)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> AddNewStudent([FromBody] AddStudentDTO SDTO)
        {
            var command = new AddStudentCommand(SDTO);

            var Student = await Sender.Send(command);

            return NewResult(Student);

        }



        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpPut(Router.StudentRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> UpdateStudentInfo(string StudentNumber, [FromBody] UpdateInfoDTO DTO)
        {
            var command = new UpdateStudentInfoCommand(DTO, StudentNumber);

            var response = await Sender.Send(command);

            return NewResult(response);

        }




        [Authorize(Roles = nameof(enRole.Student))]
        [HttpPut(Router.StudentRouter.ChangePassword)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> ChangePassword(string StudentNumber, string CurrentPassword, string NewPassword)
        {
            ChangePasswordCommandDTO DTO = new ChangePasswordCommandDTO(StudentNumber, CurrentPassword, NewPassword);

            var command = new StudentChangePasswordCommand(DTO);

            var response = await Sender.Send(command);

            return NewResult(response);

        }

        // DELETE api/<StudentController>/{id}
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpDelete(Router.StudentRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await Sender.Send(new DeleteStudentByIdCommand(Id));
            return NewResult(response);
        }


        // DELETE api/<StudentController>/Number/{StudentNumber}
        [Authorize(Roles = nameof(enRole.Admin))]
        [HttpDelete(Router.StudentRouter.ByStudentNumber)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> Delete([FromRoute] string StudentNumber)
        {
            var response = await Sender.Send(new DeleteStudentByStudentNumberCommand(StudentNumber));
            return NewResult(response);
        }

    }
}
