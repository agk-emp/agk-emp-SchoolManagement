using SchoolProject.Core.Features.Departments.Results;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentMapping
    {
        private void GetStudentsCountPerDepartmentMapping()
        {
            CreateMap<StudentsCountPerDepartmentView,
                GetStudentsCountPerDepartmentResponse>()
                .ForMember(dep => dep.Name,
                opt => opt.MapFrom(dep =>
                dep.GetLocalizedName(dep.DNameAr, dep.DNameEn)));
        }
    }
}
