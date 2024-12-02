using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}
