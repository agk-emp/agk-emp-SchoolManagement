using SchoolProject.Core.Features.Departments.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentMapping
    {
        public void GetDepartmentByIdQueryMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>().
                ForMember(dst => dst.Id, opt => { opt.MapFrom(src => src.DID); }).
                ForMember(dst => dst.Name, opt =>
                    opt.MapFrom(src => src.GetLocalizedName(
                    src.DNameAr, src.DNameEn)))
                .ForMember(dst => dst.ManagerName, opt => opt.MapFrom(src => src.Instructor.GetLocalizedName(
                    src.Instructor.ENameAr, src.Instructor.ENameEn))).
                    ForMember(dst => dst.Instructors, opt => opt.MapFrom(src => src.Instructors)).
                    ForMember(dst => dst.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
                    .ForMember(dst => dst.Students, opt => opt.Ignore());
            //ForMember(dst => dst.Students, opt => opt.MapFrom(src => src.Students));

            //MapDepartmentStudents();
            MapDepartmentInstructor();
            MapDepartmentSubjects();
        }

        //private void MapDepartmentStudents()
        //{
        //    CreateMap<Student, DepartmentStudents>().
        //        ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.StudID)).
        //        ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.GetLocalizedName(
        //            src.NameAr, src.NameEn)));
        //}

        private void MapDepartmentInstructor()
        {
            CreateMap<Instructor, DepartmentInstructors>().
                ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.InsId)).
                ForMember(dst => dst.Name, opt => opt.MapFrom(
                    src => src.GetLocalizedName(src.ENameAr, src.ENameEn)));
        }

        private void MapDepartmentSubjects()
        {
            CreateMap<DepartmetSubject, DepartmentSubjscts>().
                ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.SubID)).
                ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Subjects.GetLocalizedName
                (src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));
        }
    }
}
