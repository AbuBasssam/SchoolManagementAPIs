using ApplicationLayer.Models;
using DomainLayer.Helper_Classes;
using MediatR;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}
