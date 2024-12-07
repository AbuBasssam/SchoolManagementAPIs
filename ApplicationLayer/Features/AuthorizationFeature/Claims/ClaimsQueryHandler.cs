using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApplicationLayer.Features.AuthorizationFeature.Claims
{
    public class ClaimsQueryHandler :IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResponse>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<DomainLayer.Entities.User> _userManager;
        private readonly ResponseHandler _response;
        #endregion
        #region Constructors
        public ClaimsQueryHandler(IAuthorizationService authorizationService, UserManager<DomainLayer.Entities.User> userManager, ResponseHandler response)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
            _response = response;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return _response.NotFound<ManageUserClaimsResponse>("User not found");
            var result = await _authorizationService.ManageUserClaimData(user);
            return _response.Success(result);
        }
        #endregion
    }
}
