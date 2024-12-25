using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Views;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentsCountPerDepartmentViewRepository
            _studentsCountPerDepartmentViewRepository;

        public DepartmentService(IDepartmentRepository departmentRepository,
            IStudentsCountPerDepartmentViewRepository studentsCountPerDepartmentViewRepository)
        {
            _departmentRepository = departmentRepository;
            _studentsCountPerDepartmentViewRepository = studentsCountPerDepartmentViewRepository;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                .Where(d => d.DID == id)
                .Include(d => d.DepartmentSubjects)
                .ThenInclude(ds => ds.Subjects)
                //.Include(d => d.Students)
                .Include(d => d.Instructor)
                .Include(d => d.Instructors)
                .FirstOrDefaultAsync();

            return department;
        }

        public async Task<bool> DoesExistWithId(int id)
        {
            return await _departmentRepository.GetTableAsTracking()
                .AnyAsync(dept => dept.DID == id);
        }

        public async Task<IEnumerable<StudentsCountPerDepartmentView>> GetStudentsForEachDepartments()
        {
            var result = await _studentsCountPerDepartmentViewRepository.GetTableNoTracking()
                .ToListAsync();
            return result ?? Enumerable.Empty<StudentsCountPerDepartmentView>();
        }
    }
}
