using SchoolProject.Core.Features.Instructors.Queries.Results;
using SchoolProject.Data.Entities.TabledFunctions;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorsMapping
    {
        private void GetInstructorsDetailsMapping()
        {
            CreateMap<GetInstructorsDetailsFunction, GetInstructorsDetailsResponse>().
                ForMember(ins => ins.Name,
                opt => opt.MapFrom(src => src.GetLocalizedName(src.ENameAr,
                src.ENameEn)));
        }
    }
}