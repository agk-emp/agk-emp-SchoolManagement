using AutoMapper;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorsMapping : Profile
    {
        public InstructorsMapping()
        {
            GetInstructorsDetailsMapping();
        }
    }
}