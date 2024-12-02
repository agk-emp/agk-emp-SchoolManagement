using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class ClaimRepository : GenericRepository<ClaimSpec>, IClaimRepository
    {
        public ClaimRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
