using ApplicationLayer.Features.Courses;
using ApplicationLayer.Features.Courses.Commands;
using ApplicationLayer.Features.Courses.Commands.Update_Course;
using ApplicationLayer.Features.Courses.Queries.GetCourseByCode;
using ApplicationLayer.Features.Courses.Queries.GetCourseByID;
using ApplicationLayer.Features.Courses.Queries.GetCourseByName;
using ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage;
using ApplicationLayer.Features.Courses.Queries.GetCoursesList;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = nameof(enRole.Admin))]

    [ApiController]
    public class CourseController : ApiController
    {

        [HttpGet(Router.CourseRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> GetCoursesPage(int PageNumber = 1)
        {
            var query = new GetCoursesPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);



            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }


        [HttpGet(Router.CourseRouter.ByCourseName)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> GetCourseByName(string CourseName)
        {
            var query = new GetCourseByNameQuery(CourseName);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            // Return the result
            return NewResult(response);
        }


        [HttpGet(Router.CourseRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> GetClassesById(int Id)
        {
            var query = new GetCourseByIDQuery(Id);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            // Return the result
            return NewResult(response);
        }


        [HttpGet(Router.CourseRouter.ByCourseCode)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]


        public async Task<IActionResult> GetCourseByCourseCode(string CourseCode)
        {
            //Set DTO Info
            var query = new GetCourseByCodeQuery(CourseCode);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            // Return the result
            return NewResult(response);
        }




        [HttpGet(Router.CourseRouter.Filter)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetCoursesFilterPage([FromQuery] CourseFilter filter, [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 10)
        {
            //Set Filter Info
            FilterInfo filterInfo = new FilterInfo { PageNumber = PageNumber, PageSize = PageSize };

            var query = new GetCoursesPageFilterQuery(filter, filterInfo);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }




        [HttpPost(Router.CourseRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.Created)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> AddNewCourse([FromBody] AddCourseCommandDTO DTO)
        {
            //Set DTO Info
            var command = new AddCourseCommand(DTO);

            // Send the command using MediatR

            var response = await Sender.Send(command);
            // Return the result

            return NewResult(response);

        }




        [HttpPut(Router.CourseRouter.BASE)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.UnprocessableEntity)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]


        public async Task<IActionResult> UpdateCourse(string CourseCode, [FromBody] UpdateCourseCommandDTO DTO)
        {
            //Set DTO Info
            var command = new UpdateCourseCommand(CourseCode, DTO);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);


        }





        [HttpPut(Router.CourseRouter.UpdatePrerequisite)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]


        public async Task<IActionResult> UpdatePrerequisiteCourse(string CourseCode, string PrerequisiteCourseCode)
        {
            //Set DTO Info
            PrerequisiteCourseCommandDTO dto = new PrerequisiteCourseCommandDTO(CourseCode, PrerequisiteCourseCode);

            var command = new ChangePrerequisiteCourseCommand(dto);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);
        }




        [HttpPut(Router.CourseRouter.AddPrerequisite)]
        [ProducesResponseType(StatusCodeRouter.BadRequest)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> AddPrerequisite(string CourseCode, string PrerequisiteCourseCode)
        {
            //Set DTO Info
            PrerequisiteCourseCommandDTO dto = new PrerequisiteCourseCommandDTO(CourseCode, PrerequisiteCourseCode);

            var command = new ChangePrerequisiteCourseCommand(dto);

            // Send the command using MediatR
            var response = await Sender.Send(command);

            // Return the result
            return NewResult(response);
        }

    }
}
