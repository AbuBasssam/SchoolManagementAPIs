using DomainLayer.App_Meta_Data;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Controllers;
using SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;
using SchoolApp.Application.Features.AuthenticationFeatrue.Commands.SignIn;
using SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

namespace School.API.Controllers;

[ApiController]
[Authorize(Roles = nameof(enRole.Admin))]

public class AuthenticationController : ApiController
{
    // POST api/<AuthenticationController>/signin

    [HttpPost(Router.AuthenticationRouter.SignIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var response = await Sender.Send(command);
        return NewResult(response);
    }

    // POST api/<AuthenticationController>/refreshToken
    [HttpPost(Router.AuthenticationRouter.RefreshToken)]
    public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenCommand command)
    {
        var response = await Sender.Send(command);
        return NewResult(response);
    }

    //POST api/<AuthenticationController>/refreshToken
    [HttpPost(Router.AuthenticationRouter.ValidateRefreshToken)]
    public async Task<IActionResult> ValidateRefreshToken([FromRoute] string token)
    {
        var response = await Sender.Send(new AuthorizeUserQuery { AccessToken = token });
        return NewResult(response);
    }
}
