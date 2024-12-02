using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UpdateUserRoles(User user, List<Role> roles);
    }
}
