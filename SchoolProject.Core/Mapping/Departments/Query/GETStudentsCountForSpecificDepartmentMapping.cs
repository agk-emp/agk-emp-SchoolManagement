using SchoolProject.Core.Features.Departments.Results;
using SchoolProject.Data.Entities.Procedures;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentMapping
    {
        private void GETStudentsCountForSpecificDepartmentMapping()
        {
            CreateMap<GETStudentsCountForDepartmentProcedure, GETStudentsCountForSpecificDepartmentResponse>()
                .ForMember(nm =>
                nm.Name, opt => opt.MapFrom(lnm =>
                lnm.GetLocalizedName(lnm.DNameAr,
                lnm.DNameEn)));
        }
    }
}