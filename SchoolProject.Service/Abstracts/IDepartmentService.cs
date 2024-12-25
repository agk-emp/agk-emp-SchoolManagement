using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);
        Task<bool> DoesExistWithId(int id);
        Task<IEnumerable<StudentsCountPerDepartmentView>> GetStudentsForEachDepartments();
    }
}
