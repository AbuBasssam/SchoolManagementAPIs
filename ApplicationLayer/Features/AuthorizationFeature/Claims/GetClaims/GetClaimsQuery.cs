using ApplicationLayer.Models;
using MediatR;

namespace SchoolApp.Application.Features.AuthorizationFeature.Claims.GetClaims;

public class GetClaimsQuery : IRequest<Response<ClaimsQueryDTO>>
{
    public int Id { get; set; }
}
