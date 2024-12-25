using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class ReplacePasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
