using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.TabledFunctions;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        IQueryable<GetInstructorsDetailsFunction> GetInstructorsDetails();
        decimal GetInstructorsTotalSalaries();
    }
}
