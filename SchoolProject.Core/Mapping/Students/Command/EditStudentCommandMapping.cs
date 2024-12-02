using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping
    {
        private void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>().
                ForMember(dest => dest.DID, opt =>
                {
                    opt.MapFrom(src => src.EditStudentCommandBody.DepartmentID);

                }).
                ForMember(dest => dest.StudID, opt =>
                {
                    opt.MapFrom(src => src.id);
                })
                .ForMember(dest => dest.NameEn, opt =>
                {
                    opt.MapFrom(src => src.EditStudentCommandBody.NameEn);
                })
                .ForMember(dest => dest.NameAr, opt =>
                {
                    opt.MapFrom(src => src.EditStudentCommandBody.NameAr);
                })
                .ForMember(dest => dest.Address, opt =>
                {
                    opt.MapFrom(src => src.EditStudentCommandBody.Address);
                })
                .ForMember(dest => dest.Phone, opt =>
                {
                    opt.MapFrom(src => src.EditStudentCommandBody.Phone);
                });
        }
    }
}
