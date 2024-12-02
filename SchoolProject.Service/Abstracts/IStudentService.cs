using SchoolProject.Data.Entities;
using SchoolProject.Data.Helper;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentById(int id);
        Task<Student> GetStudentWithoutInclude(int id);
        Task AddStudent(Student student);
        Task EditStudent(Student student);
        Task<bool> DoesExistWithNameEn(string name);
        Task<bool> DoesExistWithNameAr(string name);
        Task<bool> DoesExistWithNameEnExcludeSelf(string name, int id);
        Task<bool> DoesExistWithNameArExcludeSelf(string name, int id);
        Task DeleteStudent(Student student);
        IQueryable<Student> FilterStudents(string? search, StudentOrderingEnum? orderBy);
        IQueryable<Student> GetStudentsByDepartmentId(int departmentId);
    }
}
