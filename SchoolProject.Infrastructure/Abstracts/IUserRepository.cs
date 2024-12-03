using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.InfrastructureBases;
using System.Security.Claims;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UpdateUserClaims(User user, List<Claim> claims);
        Task UpdateUserRoles(User user, List<Role> roles);
    }
}
