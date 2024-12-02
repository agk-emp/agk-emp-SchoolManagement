using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {

        private void RegisterUserMapping()
        {
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
