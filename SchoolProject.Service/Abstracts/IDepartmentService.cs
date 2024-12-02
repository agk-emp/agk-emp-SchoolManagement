using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);
        Task<bool> DoesExistWithId(int id);
    }
}
