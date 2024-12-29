using SchoolProject.Data.Entities.TabledFunctions;

namespace SchoolProject.Service.Abstracts
{
    public interface IInstructorService
    {
        IQueryable<GetInstructorsDetailsFunction> GetInstructorsDetails();
        decimal GetInstructorsTotalSalaries();
    }
}
