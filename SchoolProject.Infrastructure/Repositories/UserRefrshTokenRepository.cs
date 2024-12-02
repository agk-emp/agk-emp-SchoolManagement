using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class UserRefrshTokenRepository : GenericRepository<UserRefreshToken>,
        IUserRefrshTokenRepository
    {
        public UserRefrshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
