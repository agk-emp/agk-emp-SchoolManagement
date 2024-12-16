using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Requests;
using SchoolProject.Service.Results;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthService
    {
        Task<bool> ConfirmEmail(int userId, string? code);
        Task<JwtResult> GetJwtToken(User user);
        JwtSecurityToken ReadAccessToken(string accessToken);
        Task<JwtResult> RefreshToken(string accessToken,
            string refreshToken);
        Task<bool> RegisterUser(RegisterUserRequest request);
        bool ValidateSignInToken(string accessToken);
    }
}
