using SchoolProject.Core.Features.Users.Queries.Results;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        private void GetUsersPaginatedMapping()
        {
            CreateMap<User, GetUsersPaginatedResponse>();
        }
    }
}
