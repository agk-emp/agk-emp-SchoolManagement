using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping
    {
        private void GetStudetsListQueryMapped()
        {
            CreateMap<Student, GetStudentList>()
                .ForMember(des => des.DepartmentName,
                opt => opt.MapFrom(src => src.Department.GetLocalizedName(src.Department.DNameAr, src.Department.DNameEn)))
                .ForMember(dst => dst.Name, opt =>
                {
                    opt.MapFrom(src => src.GetLocalizedName(src.NameAr, src.NameEn));
                });
        }
    }
}
