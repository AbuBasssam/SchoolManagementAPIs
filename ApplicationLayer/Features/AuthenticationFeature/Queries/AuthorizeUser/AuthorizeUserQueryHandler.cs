using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

public class AuthorizeUserQueryHandler : IRequestHandler<AuthorizeUserQuery, Response<string>>
{
    #region Field(s)
    private readonly IAuthService _authService;
    private readonly ResponseHandler _responseHandler1;
    #endregion

    #region Constructor(s)
    public AuthorizeUserQueryHandler(IAuthService authService, ResponseHandler responseHandler)
    {
        _authService = authService;
        _responseHandler1 = responseHandler;
    }
    #endregion


    public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
    {
        return (_authService.IsValidAccessToken(request.AccessToken)) ? _responseHandler1.Success<string>("Valid") : _responseHandler1.BadRequest<string>("Not valid");

    }
}
