using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.TabledFunctions;

namespace SchoolProject.Service.Abstracts
{
    public interface IInstructorService
    {
        Task<string> AddInstructor(Instructor instructor, IFormFile file);
        IQueryable<GetInstructorsDetailsFunction> GetInstructorsDetails();
        decimal GetInstructorsTotalSalaries();
    }
}
