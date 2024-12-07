using ApplicationLayer.Models;
using MediatR;

namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.UpdateUserRolesByUserId;

public class UpdateUserRoleByUserNameCommand : IRequest<Response<string>>
{
    public string UserName { get; set; }
    public string Role { get; set; }
}
