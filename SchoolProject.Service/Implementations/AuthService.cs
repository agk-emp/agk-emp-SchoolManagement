using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Options;
using SchoolProject.Service.Results;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly JwtOptions _jwtoOptions;
        private readonly RefreshTokenOptions _refreshTokenOptions;
        private readonly IUserRefrshTokenRepository _userRefrshTokenRepository;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManager<User> _userManager;
        IStringLocalizer<SharedResources> _localizer;

        public AuthService(IOptions<JwtOptions> options,
            IOptions<RefreshTokenOptions> refreshTokenOptions,
            IUserRefrshTokenRepository userRefrshTokenRepository,
            TokenValidationParameters tokenValidationParameters,
            UserManager<User> userManager,
            IStringLocalizer<SharedResources> localizer)
        {
            _jwtoOptions = options.Value;
            _refreshTokenOptions = refreshTokenOptions.Value;
            _userRefrshTokenRepository = userRefrshTokenRepository;
            _tokenValidationParameters = tokenValidationParameters;
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<JwtResult> GetJwtToken(User user)
        {
            var (accessToken, jwtToken) = await GenerateAceessToken(user);

            var refreshToken = GetRefreahToken(user.UserName);

            var userRefreshToken = new UserRefreshToken()
            {
                AddedTime = DateTime.Now,
                ExpiryDate = refreshToken.ExpireAt,
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = refreshToken.TokenString,
                Token = accessToken,
                UserId = user.Id
            };

            await _userRefrshTokenRepository.AddAsync(userRefreshToken);

            var response = new JwtResult()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
            return response;
        }

        public async Task<JwtResult> RefreshToken(string accessToken,
    string refreshToken)
        {
            JwtSecurityToken jwtSecurityToken = ReadAccessToken(accessToken);
            if (string.IsNullOrWhiteSpace(accessToken) ||
                string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException(SharedResourcesKeys.SomethingWrongWithTokens);
            }

            if (ValidateAccessToken(jwtSecurityToken) == false)
            {
                throw new Exception(SharedResourcesKeys.ThisAccessTokenDoesNotMeetOurSecurityStandards);
            }

            var userId = GetUserIdFromAccessToken(jwtSecurityToken);
            var refreshTokenResult = await _userRefrshTokenRepository.GetTableAsTracking()
                .FirstOrDefaultAsync(refTok => refTok.RefreshToken == refreshToken
                && refTok.Token == accessToken &&
                refTok.UserId == userId);

            if (refreshTokenResult is null)
            {
                throw new Exception(SharedResourcesKeys.ThisRefreshTokenDoesNotExist);
            }

            if (refreshTokenResult.IsRevoked)
            {
                throw new Exception(SharedResourcesKeys.ThisRefreshTokenWasRevoked);
            }

            if (refreshTokenResult.ExpiryDate < DateTime.UtcNow)
            {
                throw new Exception(SharedResourcesKeys.TheRefreshTokenIsValid);
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
            {
                throw new Exception(SharedResourcesKeys.NotFound);
            }

            var refTok = GetRefreahToken(user.UserName);

            var token = await GenerateAceessToken(user);

            var userRefreshToken = new UserRefreshToken()
            {
                AddedTime = DateTime.Now,
                ExpiryDate = refTok.ExpireAt,
                IsUsed = true,
                IsRevoked = false,
                JwtId = token.jwtSecurityToken.Id,
                RefreshToken = refTok.TokenString,
                Token = accessToken,
                UserId = user.Id
            };

            var result = new JwtResult()
            {
                RefreshToken = refTok,
                AccessToken = token.accessToken,
            };

            await _userRefrshTokenRepository.AddAsync(userRefreshToken);
            return result;
        }

        public bool ValidateSignInToken(string accessToken)
        {
            var jwtToken = ReadAccessToken(accessToken);
            if (ValidateAccessToken(jwtToken) && ValidateAccessTokenExpiry(jwtToken))
            {
                return true;
            }

            return false;
        }

        public JwtSecurityToken ReadAccessToken(string accessToken)
        {
            JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            return jwtToken;
        }

        private RefreshToken GetRefreahToken(string userName)
        {
            return new RefreshToken()
            {
                ExpireAt = DateTime.UtcNow.AddSeconds(_refreshTokenOptions.ExpireAt),
                UserName = userName,
                TokenString = GenerateRefreshToken(),
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<List<Claim>> GetUserClaims(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.PhoneNumber,user.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };
            AddUserRolesToClaims(userRoles, claims);
            return claims;
        }

        private static void AddUserRolesToClaims(IList<string> userRoles, List<Claim> claims)
        {
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }

        private int GetUserIdFromAccessToken(JwtSecurityToken jwtSecurityToken)
        {
            if (jwtSecurityToken is null)
            {
                throw new ArgumentNullException(SharedResourcesKeys.ThereIsNoTokenToRead);
            }
            var userId = jwtSecurityToken.Claims.FirstOrDefault(clm => clm.Type == ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userId);
        }

        private bool ValidateAccessToken(JwtSecurityToken jwtToken)
        {
            var accessToken = jwtToken.RawData;
            if (jwtToken.Header.Alg is not SecurityAlgorithms.HmacSha256)
            {
                return false;
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var result = tokenHandler.ValidateToken(accessToken,
                    _tokenValidationParameters, out var validatedToken);
                if (validatedToken is JwtSecurityToken)
                {
                    return true;
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool ValidateAccessTokenExpiry(JwtSecurityToken token)
        {
            if (token.ValidTo < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        private async Task<(string accessToken, JwtSecurityToken jwtSecurityToken)> GenerateAceessToken(User user)
        {
            var jwtToken = new JwtSecurityToken(
                     issuer: _jwtoOptions.Issuer,
                     audience: _jwtoOptions.Audience,
                     claims: await GetUserClaims(user),
                     expires: DateTime.UtcNow.AddSeconds(_jwtoOptions.Expires),
                     signingCredentials: new SigningCredentials(
                     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtoOptions.SecretKey)),
                     SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return (accessToken, jwtToken);
        }
    }
}