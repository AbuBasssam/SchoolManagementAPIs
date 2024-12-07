
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Helper_Classes;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
{
    #region Field(s)
    private readonly IAuthService _authenticationService;
    private readonly IUserService _userService;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor
    public RefreshTokenCommandHandler(IAuthService authenticationService, IUserService userService, ResponseHandler responseHandler)
    {
        _authenticationService = authenticationService;
        _userService = userService;
        _responseHandler = responseHandler;
    }
    #endregion

    #region Handler
    public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // 1) Get JwtSecurityToken Object
        var (jwtAccessTokenObj, jwtAccessTokenEx) = _authenticationService.GetJwtAccessTokenObjFromAccessTokenString(request.AccessToken);
        if (jwtAccessTokenEx != null) return _responseHandler.BadRequest<JwtAuthResult>("Invalid token");

        // 2) Get Claims Principle
        var (claimsPrinciple, claimsPrincipleEx) = _authenticationService.GetClaimsPrinciple(request.AccessToken);
        if (claimsPrincipleEx != null) return _responseHandler.BadRequest<JwtAuthResult>("Invalid token");

        // 3) Get UserId
        var (userId, userIdEx) = _authenticationService.GetUserIdFromJwtAccessTokenObj(jwtAccessTokenObj!);
        if (userIdEx != null) return _responseHandler.BadRequest<JwtAuthResult>("Invalid token");

        // 4) Validate RefreshToken
        var (refreshTokenObj, refreshTokenEx) = await _authenticationService.ValidateRefreshToken(userId, request.AccessToken, request.RefreshToken);

        // 5) Get User
        var user = await _userService.GetById(userId).Include(u => u.Role).FirstOrDefaultAsync();

        if (user == null)
            return _responseHandler.BadRequest<JwtAuthResult>("Invalid token");

        // 6) get new JwtAuth
        var jwtAuth = await _authenticationService.GetJwtAuthForuser(user);

        return _responseHandler.Success(jwtAuth);
    }
    #endregion
}
