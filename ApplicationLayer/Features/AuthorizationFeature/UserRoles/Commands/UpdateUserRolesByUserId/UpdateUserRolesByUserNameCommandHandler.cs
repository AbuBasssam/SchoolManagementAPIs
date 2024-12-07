
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.UpdateUserRolesByUserId;

class UpdateUserRolesByUserNameCommandHandler : IRequestHandler<UpdateUserRoleByUserNameCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructure(s)
    public UpdateUserRolesByUserNameCommandHandler(IAuthorizationService authorizationService, IUserService userService, IMapper mapper, ResponseHandler responseHandler)
    {
        _authorizationService = authorizationService;
        _userService = userService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }
    #endregion


    #region Handler
    public async Task<Response<string>> Handle(UpdateUserRoleByUserNameCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(request.UserName).FirstOrDefaultAsync();

        if (user == null) return _responseHandler.NotFound<string>("No user found with the provided id");



        var role = await _authorizationService.GetRoleByName(request.Role).AsNoTracking().FirstOrDefaultAsync();

        if (role == null) return _responseHandler.NotFound<string>($"No role found with the provided name `{request.Role}`");

        // user.RoleID = role.Id;
        // user.Role = role;

        var UpdateResult = await _userService.UpdateUserRoleAsync(request.UserName, role.Id);

        return UpdateResult ? _responseHandler.Success("Roles for this user updated succesfully") : _responseHandler.BadRequest<string>("Error");

    }
    #endregion
}
