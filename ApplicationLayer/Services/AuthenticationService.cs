using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationLayer.Services
{
    public class AuthenticationService : IAuthService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly IUserService _userService;
        private readonly SymmetricSecurityKey _signaturekey;
        private static string _SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature;
        private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        #endregion

        #region Constructor(s)
        public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepo, IUserService userService)
        {
            _jwtSettings = jwtSettings;
            _refreshTokenRepo = refreshTokenRepo;
            _signaturekey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
            _userService = userService;
        }
        #endregion

        #region Methods
        public async Task<JwtAuthResult> GetJwtAuthForuser(User User)
        {
            // 1) Check if the user already has an active refresh token 
            //var existingToken = await _refreshTokenRepo.GetTableNoTracking().FirstOrDefaultAsync(x => x.UserId == User.Id && x.IsUsed && x.IsRevoked == false);

            //if (existingToken != null)
            //{

            //    throw new Exception("\"The user already has an active token");
            //    //// Revoke the existing token before issuing a new one
            //    //existingToken.IsRevoked = true;
            //    //await _refreshTokenRepo.UpdateAsync(existingToken);
            //}

            // 2) Generate jwtAccessTokon Object And String
            var (jwtAccessTokenObj, jwtAccessTokenString) = await GenerateAccessToken(User);

            // 3) Generate RefreshToken Object
            var refreshTokenObj = GenerateRefreshToken(User);

            // 4) Generate the JwtAuth for the user
            var jwtAuthResult = new JwtAuthResult
            {
                AccessToken = jwtAccessTokenString,
                RefreshToken = refreshTokenObj
            };

            // 5) Save AccessToken, RefreshToken In UserRefreshToken Table
            var refreshTokenEntity = new UserRefreshToken
            {
                UserId = User.Id,
                AccessToken = jwtAccessTokenString,
                RefreshToken = HashString(refreshTokenObj.Value),
                JwtId = jwtAccessTokenObj.Id,
                IsUsed = true,
                IsRevoked = false,
                CreatedAt = DateTime.UtcNow,
                ExpiryDate = refreshTokenObj.ExpiresAt,
            };
            var result = await _refreshTokenRepo.AddAsync(refreshTokenEntity);

            // 6) return the AuthResult for the user
            return jwtAuthResult;
        }

        public bool IsValidAccessToken(string AccessTokenStr)
        {
            try
            {
                var (jwtAccessTokenObj, jwtAccesTokenEx) = GetJwtAccessTokenObjFromAccessTokenString(AccessTokenStr);
                if (jwtAccesTokenEx != null) return false;

                GetClaimsPrinciple(AccessTokenStr);

                if (jwtAccessTokenObj!.ValidTo < DateTime.UtcNow) return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        #region AccessToken Methods
        private List<Claim> GenerateUserClaims(User User, string RoleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, User.UserName!),
                new Claim(ClaimTypes.Name, User.UserName!),
                new Claim(ClaimTypes.Email, User.Email!),
                new Claim(nameof(UserClaimModel.Id), User.Id.ToString()),
                new Claim(ClaimTypes.Role, RoleName)
            };

            //foreach (var role in Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            return claims;
        }
        private async Task<(JwtSecurityToken, string)> GenerateAccessToken(User User)
        {



            /*            List<string> roles = await _userService.GetUserRoleAsync(User);

            List<string> strRoles = new List<string>();
            foreach (var item in roles)
            {
                strRoles.Add(item.ToString());
            }

            // Generate a unique identifier for the JWT (jti)

            //var jwtId = Guid.NewGuid().ToString();

            var token = new JwtSecurityToken(

                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: GenerateUserClaims(User, User.Role.Name!),
                expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(_signaturekey, _SecurityAlgorithm)
            );

            var Value = new JwtSecurityTokenHandler().WriteToken(token);
            return (token, Value);*/


            //List<string> roles = await _userService.GetUserRolesAsync(User);

            // Generate a unique identifier for the JWT (jti)

            var jwtId = Guid.NewGuid().ToString();

            var claims = GenerateUserClaims(User, User.Role.Name!);

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, jwtId));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(_signaturekey, _SecurityAlgorithm)
            );

            // Debug: Check claims for jti
            Console.WriteLine("Claims in Token:");
            foreach (var claim in token.Claims)
            {
                Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
            }

            // Generate token string
            var tokenString = _tokenHandler.WriteToken(token);

            return (token, tokenString);
        }
        public (JwtSecurityToken?, Exception?) GetJwtAccessTokenObjFromAccessTokenString(string AccessToken)
        {
            try
            {
                return ((JwtSecurityToken)_tokenHandler.ReadToken(AccessToken), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
        public (ClaimsPrincipal?, Exception?) GetClaimsPrinciple(string AccessToken)
        {
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },

                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidAudience = _jwtSettings.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = _tokenHandler.ValidateToken(AccessToken, parameters, out SecurityToken validationToken);

                if (validationToken is JwtSecurityToken jwtToken && jwtToken.Header.Alg.Equals(_SecurityAlgorithm))
                    return (principal, null);

                return (null, new ArgumentNullException("Claims principle is null"));
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }


        public (int, Exception?) GetUserIdFromJwtAccessTokenObj(JwtSecurityToken jwtAccessTokenObj)
        {
            if (!int.TryParse(jwtAccessTokenObj.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id))?.Value, out int UserId))
                return (0, new ArgumentNullException("Invalid user id"));

            return (UserId, null);
        }
        #endregion


        #region RefreshToken Methods
        private RefreshToken GenerateRefreshToken(User User)
        {
            return new RefreshToken()
            {
                Username = User.UserName!,
                Value = GenerateRandomString64Length(),
                ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDate)
            };
        }
        public async Task<(UserRefreshToken?, Exception?)> ValidateRefreshToken(int UserId, string AccessTokenStr, string RefreshTokenStr)
        {
            var hashedRefreshTokenStr = HashString(RefreshTokenStr);

            var refreshTokenEntity = await _refreshTokenRepo
                .GetTableNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.UserId == UserId &&
                    x.AccessToken.Equals(AccessTokenStr) &&
                    x.RefreshToken.Equals(hashedRefreshTokenStr) &&
                   !x.IsRevoked
                );

            if (refreshTokenEntity == null)
                return (null, new SecurityTokenArgumentException("Refresh token entity is null"));

            if (refreshTokenEntity.ExpiryDate < DateTime.UtcNow)
            {
                refreshTokenEntity.IsRevoked = true;
                refreshTokenEntity.IsUsed = false;
                await _refreshTokenRepo.UpdateAsync(refreshTokenEntity);
                return (null, new SecurityTokenArgumentException("Revoked refresh token"));
            }

            return (refreshTokenEntity, null);
        }
        #endregion


        #region Helpers
        private string GenerateRandomString64Length()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private string HashString(string Value)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Value)).ToArray();
                return Convert.ToBase64String(hashedBytes);
            }
        }
        #endregion

    }


}
