using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
