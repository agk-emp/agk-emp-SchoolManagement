using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;
using System.Security.Claims;

namespace SchoolProject.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationDbContext dbContext,
            UserManager<User> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public async Task UpdateUserRoles(User user, List<Role> roles)
        {
            BeginTransaction();
            try
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var removingRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                if (!removingRolesResult.Succeeded)
                {
                    RollBack();
                    return;
                }
                var updatingRolesResult = await _userManager.AddToRolesAsync(user, roles.Select(role => role.Name));
                if (!updatingRolesResult.Succeeded)
                {
                    RollBack();
                    return;
                }
                Commit();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task UpdateUserClaims(User user, List<Claim> claims)
        {
            BeginTransaction();

            try
            {
                if (await RemoveClaimsFromUser(user) == false)
                {
                    RollBack();
                    return;
                }
                if (await AddClaimsToUser(user, claims) == false)
                {
                    RollBack();
                    return;
                }
                Commit();
            }
            catch
            {
                RollBack();
            }
        }

        private async Task<bool> AddClaimsToUser(User user, List<Claim> claims)
        {
            var addingClaimsResult = await _userManager.AddClaimsAsync(user, claims);
            if (!addingClaimsResult.Succeeded)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> RemoveClaimsFromUser(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var removingClaimsResult = await _userManager.RemoveClaimsAsync(user, userClaims);
            if (!removingClaimsResult.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}