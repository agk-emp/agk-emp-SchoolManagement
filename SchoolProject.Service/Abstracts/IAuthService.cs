using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Results;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthService
    {
        Task<JwtResult> GetJwtToken(User user);
        JwtSecurityToken ReadAccessToken(string accessToken);
        Task<JwtResult> RefreshToken(string accessToken,
            string refreshToken);
        bool ValidateSignInToken(string accessToken);
    }
}
