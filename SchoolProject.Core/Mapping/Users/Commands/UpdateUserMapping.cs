using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        private void UpdateUserMapping()
        {
            CreateMap<EditUserCommand, User>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(
                    src => src.id))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src =>
                src.EditUserBody.Email))
                .ForMember(dst => dst.FullName,
                opt => opt.MapFrom(src => src.EditUserBody.FullName))
                .ForMember(dst => dst.PhoneNumber, opt =>
                opt.MapFrom(src => src.EditUserBody.PhoneNumber))
                .ForMember(dst => dst.UserName,
                opt => opt.MapFrom(src => src.EditUserBody.UserName))
                .ForMember(dst => dst.Address, opt =>
                opt.MapFrom(src => src.EditUserBody.Address))
                .ForMember(dst => dst.Country, opt =>
                opt.MapFrom(src => src.EditUserBody.Country));
        }
    }
}
