using ApplicationLayer.Features.AuthorizationFeature.Claims;
using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Controllers;
using SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRolesList;
using SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.UpdateUserRolesByUserId;
using Swashbuckle.AspNetCore.Annotations;

namespace School.API.Controllers;

[Authorize(Roles = nameof(enRole.Admin))]
[ApiController]
public class AuthorizationController : ApiController
{
    // GET api/<AuthorizationController>
    [HttpGet(Router.AuthorizationRouter.RoleRouter.BASE)]
    public async Task<IActionResult> Get()
    {
        var response = await Sender.Send(new GetRolesListQuery());
        return NewResult(response);
    }

    [HttpPut(Router.AuthorizationRouter.UpdateUserRole)]
    public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleByUserNameCommand command)
    {
        var response = await Sender.Send(command);
        return NewResult(response);
    }

    [SwaggerOperation(Summary = " ادارة صلاحيات الاستخدام المشرفين", OperationId = "ManageAdminClaims")]
    [HttpGet(Router.AuthorizationRouter.ManageUserClaims)]
    public async Task<IActionResult> ManageUserClaims([FromRoute] string UserName)
    {
        var response = await Sender.Send(new ManageUserClaimsQuery() { UserName = UserName });
        return NewResult(response);
    }
    [SwaggerOperation(Summary = " تعديل صلاحيات  الاستخدام المشرفين", OperationId = "UpdateAdminClaims")]
    [HttpPut(Router.AuthorizationRouter.UpdateUserClaims)]
    public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
    {
        var response = await Sender.Send(command);
        return NewResult(response);
    }

    /*// GET api/<AuthorizationController>/{id}
   [SwaggerOperation(Summary = "Get the role by Id", OperationId = "Get")]
   [HttpGet(Router.AuthorizationRouter.RoleRouter.ById)]
   public async Task<IActionResult> Get([FromRoute] int Id)
   {
       var response = await Sender.Send(new GetRoleByIdQuery(Id));
       return NewResult(response);
   }*/

    /*// POST api/<AuthorizationController>/Create
    //[HttpPost(Router.AuthorizationRouter.RoleRouter.BASE)]
    //public async Task<IActionResult> Post([FromQuery] AddRoleCommand command)
    //{
    //    var response = await Sender.Send(command);
    //    return NewResult(response);
    //}
    */

    /*// PUT api/<AuthorizationController>/{id}
    //[HttpPut(Router.AuthorizationRouter.RoleRouter.ById)]
    //public async Task<IActionResult> Put(int Id, [FromBody] UpdateRoleByIdDTO data)
    //{
    //    var response = await Sender.Send(new UpdateRoleByIdCommand { Id = Id, RoleData = data });
    //    return NewResult(response);
    //}*/

    /*// DELETE api/<AuthorizationController>/{id}
    //[HttpDelete(Router.AuthorizationRouter.RoleRouter.ById)]
    //public async Task<IActionResult> Delete([FromRoute] int Id)
    //{
    //    var response = await Sender.Send(new DeleteRoleByIdCommand(Id));
    //    return NewResult(response);
    //}*/
}
