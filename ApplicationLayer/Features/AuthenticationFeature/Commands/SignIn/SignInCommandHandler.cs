
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Helper_Classes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<JwtAuthResult>>
{
    #region Field
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor
    public SignInCommandHandler(IUserService userService, IAuthService authService, IMapper mapper, ResponseHandler responseHandler)
    {
        _userService = userService;
        _authService = authService;
        _mapper = mapper;
        _responseHandler = responseHandler;

    }
    #endregion

    #region Handler
    public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(request.Username).Include(u => u.Role).FirstOrDefaultAsync();

        if (user == null || !await _userService.CheckPasswordAsync(user, request.Password))
            return _responseHandler.BadRequest<JwtAuthResult>($"Invalid username and/or password");

        var JwtAuthResult = await _authService.GetJwtAuthForuser(user);

        return _responseHandler.Success(JwtAuthResult);
    }
    #endregion
}
