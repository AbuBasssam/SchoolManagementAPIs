using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.AuthorizationFeature.Claims
{
    public class ClaimsCommandHandler : IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        #region Fileds
        private readonly ResponseHandler _response;
        private readonly IAuthorizationService _authorizationService;

        #endregion
        #region Constructors
        public ClaimsCommandHandler(ResponseHandler response, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _response = response;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserIsNull": return _response.NotFound<string>("User not found");
                case "FailedToRemoveOldClaims": return _response.BadRequest<string>("FailedToRemoveOldClaims");
                case "FailedToAddNewClaims": return _response.BadRequest<string>("FailedToAddNewClaims");
                case "FailedToUpdateClaims": return _response.BadRequest<string>("FailedToUpdateClaims");
            }
            return _response.Success<string>("Success");
        }
        #endregion
    }
}
