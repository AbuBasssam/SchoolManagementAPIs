using ApplicationLayer.Models;
using DomainLayer.Requests;
using MediatR;

namespace ApplicationLayer.Features.AuthorizationFeature.Claims
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
