using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.AuthenticationServices.Abstracts
{
    public interface ICurrentUserService
    {
        Task<IEnumerable<string>?> GetCurrentUserRoles();
        Task<User> GetUser();
        int GetUserId();
    }
}
