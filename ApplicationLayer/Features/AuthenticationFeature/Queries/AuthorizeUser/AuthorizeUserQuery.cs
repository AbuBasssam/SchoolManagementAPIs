using ApplicationLayer.Models;
using MediatR;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

public class AuthorizeUserQuery : IRequest<Response<string>>
{
    public string AccessToken { get; set; } = null!;
}
