using ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment;
using ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses;
using ApplicationLayer.Features.EnrollmentFeature.Commands.DeleteEnrollment;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Authorize(Roles = $"{nameof(enRole.Student)},{nameof(enRole.Admin)}")]
    public class EnrollmentController : ApiController
    {

        [HttpGet(Router.EnrollmentRouter.AvailableCourses)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]


        public async Task<IActionResult> GeAvailableEnrollmentCourses(string StudentNumber)
        {
            var query = new GeAvailableEnrollmentCoursesQuery(StudentNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);

        }

        [HttpPost(Router.EnrollmentRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        public async Task<IActionResult> AddNewEnrollment(AddNewEnrollmentCommandDTO DTO)
        {
            var command = new AddNewEnrollmentCommand(DTO);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);

        }


        [HttpDelete(Router.EnrollmentRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> DeleteEnrollment(string StudentNumber, string SectionNumber)
        {


            var command = new DeleteEnrollmentCommand(StudentNumber, SectionNumber);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            //Return the result
            return NewResult(response);

        }
    }
}
