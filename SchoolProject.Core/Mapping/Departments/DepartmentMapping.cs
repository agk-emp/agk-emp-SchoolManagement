using AutoMapper;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentMapping : Profile
    {
        public DepartmentMapping()
        {
            GetDepartmentByIdQueryMapping();
        }
    }
}
