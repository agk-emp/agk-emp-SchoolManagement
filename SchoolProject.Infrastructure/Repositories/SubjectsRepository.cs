using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectsRepository : GenericRepository<Subjects>, ISubjectsRepository
    {
        public SubjectsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
