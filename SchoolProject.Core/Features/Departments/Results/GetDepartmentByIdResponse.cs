using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Results
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public List<DepartmentInstructors> Instructors { get; set; } = new();
        public PaginatedResponse<DepartmentStudents>? Students { get; set; }
        public List<DepartmentSubjscts> Subjects { get; set; } = new();
    }
}
