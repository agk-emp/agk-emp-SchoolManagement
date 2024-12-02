using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping
    {
        private void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dst => dst.DID, opt =>
                {
                    opt.MapFrom(src => src.DepartmentID);
                })
                .ForMember(dst => dst.NameEn, opt =>
                {
                    opt.MapFrom(src => src.NameEn);
                })
                .ForMember(dst => dst.NameAr, opt =>
                {
                    opt.MapFrom(src => src.NameAr);
                });
        }
    }
}
