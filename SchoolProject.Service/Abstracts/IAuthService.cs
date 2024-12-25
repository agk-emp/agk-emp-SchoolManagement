using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Requests;
using SchoolProject.Service.Results;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthService
    {
        Task<bool> ConfirmEmail(int userId, string? code);
        Task<bool> ConfirmPasswordResetting(string email, string code);
        Task<JwtResult> GetJwtToken(User user);
        JwtSecurityToken ReadAccessToken(string accessToken);
        Task<JwtResult> RefreshToken(string accessToken,
            string refreshToken);
        Task<bool> RegisterUser(RegisterUserRequest request);
        Task<bool> ReplacePassword(string email, string password);
        Task<bool> ResetPassword(string email);
        bool ValidateSignInToken(string accessToken);
    }
}
