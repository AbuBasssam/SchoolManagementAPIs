using ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalConditionByConditionName;
using ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalConditionByID;
using ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalContionsList;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Authorize(Roles = nameof(enRole.Admin))]

    public class MedicalConditionController : ApiController
    {

        [HttpGet(Router.MedicalConditionRouter.Query)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GetMedicalConditionsPage(int PageNumber = 1)
        {
            var query = new GetMedicalConditionsPageQuery(PageNumber);

            // Send the query using MediatR
            var MedicalConditions = await Sender.Send(query);

            // Return the result
            return MedicalConditions.Succeeded ? Ok(MedicalConditions) : NotFound(MedicalConditions);
        }


        [HttpGet(Router.MedicalConditionRouter.ByMedicalConditionName)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]
        public async Task<IActionResult> GettMedicalConditionByConditionName([FromRoute] string MedicalConditionName)
        {
            var query = new GetMedicalConditionsByConditionNameQuery(MedicalConditionName);

            // Send the query using MediatR
            var MedicalCondition = await Sender.Send(query);


            // Return the result
            return NewResult(MedicalCondition);
        }




        [HttpGet(Router.MedicalConditionRouter.ById)]
        [ProducesResponseType(StatusCodeRouter.OK)]
        [ProducesResponseType(StatusCodeRouter.NotFound)]
        [ProducesResponseType(StatusCodeRouter.InternalServerError)]
        [ProducesResponseType(StatusCodeRouter.Unauthorized)]

        public async Task<IActionResult> MedicalConditionById([FromRoute] int Id)
        {
            var query = new GetMedicalConditionsByIDQuery(Id);

            // Send the query using MediatR
            var MedicalCondition = await Sender.Send(query);


            // Return the result
            return NewResult(MedicalCondition);
        }
    }
}
