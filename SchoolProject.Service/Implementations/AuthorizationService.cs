using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Requests;
using SchoolProject.Service.Results;

namespace SchoolProject.Service.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public AuthorizationService(RoleManager<Role> roleManager,
            UserManager<User> userManager,
            IUserRepository userRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<bool> AddRole(string roleName)
        {
            var role = new Role()
            {
                Name = roleName,
            };
            if (await DoesRoleExist(roleName))
            {
                return false;
            }
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DoesRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> EditRole(int id, string name)
        {
            Role? role = await GetRoleById(id);

            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        private async Task<Role?> GetRoleById(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role is null)
            {
                throw new Exception(SharedResourcesKeys.ThereIsNoSuchRole);
            }

            return role;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await GetRoleById(id);
            var usersWithRole = await _userManager.GetUsersInRoleAsync(role.Name);
            if (usersWithRole is not null && usersWithRole.Any())
            {
                throw new Exception(SharedResourcesKeys.UsersExistWithThisRole);
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Role>> GetRoles()
        {
            var result = await _roleManager.Roles.ToListAsync();
            if (result is null || !result.Any())
            {
                return Enumerable.Empty<Role>().ToList();
            }
            return result;
        }

        public async Task<Role> GetById(int id)
        {
            return await GetRoleById(id);
        }

        public async Task<UserWithRolesAvailability>
            GetUserWithRolesChecker(int userId)
        {
            UserWithRolesAvailability result = new();
            var user = await GetUserById(userId);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            var rolesUserChecker = new List<UserWithRolesAvailability.RolesForUserChecker>();

            foreach (var role in roles)
            {
                var roleUserChecker = new UserWithRolesAvailability.RolesForUserChecker();
                roleUserChecker.Name = role.Name;
                roleUserChecker.Id = role.Id;
                roleUserChecker.HasRole = userRoles.Contains(role.Name) ? true : false;

                rolesUserChecker.Add(roleUserChecker);
            }

            result.UserId = userId;
            result.RolesChecker = rolesUserChecker;
            return result;
        }

        public async Task UpdateUserRoles(UpdateUserRoles requestDto)
        {
            var user = await GetUserById(requestDto.id);
            var rolesUpdated = new List<Role>();
            foreach (var roleDto in requestDto.RolesUpdatedBody)
            {
                Role role = await _roleManager.FindByIdAsync(roleDto.Id.ToString());
                rolesUpdated.Add(role);
            }
            await _userRepository.UpdateUserRoles(user, rolesUpdated);

        }

        private async Task<User> GetUserById(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new Exception(SharedResourcesKeys.NotFound);
            }
            return user;
        }
    }
}
