using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class ClaimRepository : GenericRepository<ClaimSpec>, IClaimRepository
    {
        private readonly UserManager<User> _userManager;
        public ClaimRepository(ApplicationDbContext dbContext,
            UserManager<User> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }
    }
}
