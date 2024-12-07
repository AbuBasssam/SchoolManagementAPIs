using DomainLayer.Entities;
using DomainLayer.Helper_Classes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApplicationLayer.Interfaces
{
    public interface IAuthService
    {
        Task<JwtAuthResult> GetJwtAuthForuser(User User);
        (int, Exception?) GetUserIdFromJwtAccessTokenObj(JwtSecurityToken jwtAccessTokenObj);
        bool IsValidAccessToken(string AccessTokenStr);
        (JwtSecurityToken?, Exception?) GetJwtAccessTokenObjFromAccessTokenString(string AccessToken);
        (ClaimsPrincipal?, Exception?) GetClaimsPrinciple(string AccessToken);
        Task<(UserRefreshToken?, Exception?)> ValidateRefreshToken(int UserId, string AccessTokenStr, string RefreshTokenStr);
    }



}
