using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstracts.Views;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories.Views
{
    public class StudentsCountPerDepartmentViewRepository :
        GenericRepository<StudentsCountPerDepartmentView>, IStudentsCountPerDepartmentViewRepository
    {
        public StudentsCountPerDepartmentViewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
