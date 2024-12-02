using AutoMapper;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping : Profile
    {
        public StudentMapping()
        {
            GetStudetsListQueryMapped();
            GetStudentByIdQueryMapping();
            GetStudentsPaginatedMapped();

            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
