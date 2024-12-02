using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Authorization
{
    public partial class AuthorizationProfile
    {
        private void GetRolesMapping()
        {
            CreateMap<Role, GetRolesResult>();
        }
    }
}
