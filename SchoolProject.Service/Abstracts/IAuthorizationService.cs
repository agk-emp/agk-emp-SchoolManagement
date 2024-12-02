using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Requests;
using SchoolProject.Service.Results;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthorizationService
    {
        Task<bool> AddRole(string roleName);
        Task<bool> DeleteRole(int id);
        Task<bool> DoesRoleExist(string roleName);
        Task<bool> EditRole(int id, string name);
        Task<Role> GetById(int id);
        Task<List<Role>> GetRoles();
        Task<UserWithRolesAvailability> GetUserWithRolesChecker(int userId);
        Task UpdateUserRoles(UpdateUserRoles requestDto);
    }
}
