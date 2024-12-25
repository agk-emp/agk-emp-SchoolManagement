using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.AuthenticationServices.Abstracts;
using System.Security.Claims;

namespace SchoolProject.Service.AuthenticationServices.Implementations
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public int GetUserId()
        {
            var userId = _contextAccessor.HttpContext.User.
                Claims.SingleOrDefault(claim => claim.Type ==
                ClaimTypes.NameIdentifier)?.Value;

            ArgumentNullException.ThrowIfNull(userId);

            return int.Parse(userId);
        }

        public async Task<User> GetUser()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());

            ArgumentNullException.ThrowIfNull(user);
            return user;
        }

        public async Task<IEnumerable<string>?> GetCurrentUserRoles()
        {
            var user = await GetUser();
            var roles = await _userManager.GetRolesAsync(user)
                ?? Enumerable.Empty<string>();
            return roles;
        }
    }
}
