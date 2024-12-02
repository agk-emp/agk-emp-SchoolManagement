using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

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
    }
}