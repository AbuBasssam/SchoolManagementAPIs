using ApplicationLayer.Features.Classes.Queries.Get_Filter_Classes;
using ApplicationLayer.Features.Classes.Queries.GetClassByID;
using ApplicationLayer.Features.Classes.Queries.GetClassesByName;
using ApplicationLayer.Features.Classes.Queries.GetClassesList;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Authorize(Roles = nameof(enRole.Admin))]

    public class ClassesController : ApiController
    {

        [HttpGet(Router.ClassRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        public async Task<IActionResult> GetClassesPage(int PageNumber = 1)
        {
            var query = new GetClassesPageQuery(PageNumber);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return response.Succeeded ? Ok(response) : NotFound(response);
        }


        [HttpGet(Router.ClassRouter.ByClassName)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]

        public async Task<IActionResult> GetClassesByClassName([FromRoute] string ClassName)
        {
            var query = new GetClassByNameQuery(ClassName);

            // Send the query using MediatR
            var response = await Sender.Send(query);


            // Return the result
            return NewResult(response);
        }




        [HttpGet(Router.ClassRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]


        public async Task<IActionResult> GetClassesById([FromRoute] int Id)
        {
            var query = new GetClassByIDQuery(Id);

            // Send the query using MediatR
            var classes = await Sender.Send(query);

            // Return the result
            return NewResult(classes);
        }




        /// <summary>
        /// Filters classes based on the specified criteria.
        /// </summary>
        /// <param name="ClassType">Specifies the type of class to filter 0:Theory 1: Practical.</param>
        /// <param name="ClassCapacity">Specifies the capacity of the class.</param>
        /// <param name="ComparisonType">Specifies the comparison type for filtering
        /// 1:Equal 2: Greater Than 3: Less Than 4: Greater Than or equal 5 :Less Than or equal.</param>
        ///
        /// <returns>A filtered list of classes.</returns>
        [HttpGet(Router.ClassRouter.Filter)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        public async Task<IActionResult> FilterClasses([FromQuery] enType? ClassType, [FromQuery] byte? ClassCapacity, [FromQuery, Required] enComparisonType ComparisonType)
        {
            // Set Filter DTO
            FilterClassesDTO filter = new FilterClassesDTO(ClassType, ClassCapacity, ComparisonType);

            var query = new GetFilterClassesQuery(filter);

            // Send the query using MediatR
            var response = await Sender.Send(query);

            // Return the result
            return NewResult(response);
        }

    }
}
