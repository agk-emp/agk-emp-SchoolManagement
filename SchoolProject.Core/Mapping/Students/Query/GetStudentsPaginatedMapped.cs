using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping
    {
        public void GetStudentsPaginatedMapped()
        {
            CreateMap<Student, GetStudentsPaginated>()
                .ForMember(dst => dst.StudID, opt => opt.MapFrom(src => src.StudID)).
                ForMember(dst => dst.Name, opt => opt.MapFrom(src =>
                src.GetLocalizedName(src.NameAr, src.NameEn)))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dst => dst.DepartmentName, opt => opt.MapFrom(src => src.Department
                .GetLocalizedName(src.Department.DNameAr, src.Department.DNameEn)));
        }
    }
}
