using ApplicationLayer.Models;
using ApplicationLayer.Resources;
using DomainLayer.Responses;
using MediatR;
using Microsoft.Extensions.Localization;

namespace ApplicationLayer.Features.AuthorizationFeature.Claims
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResponse>>
    {
        public string UserName { get; set; }
    }
}
