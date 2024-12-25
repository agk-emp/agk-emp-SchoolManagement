using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class ConfirmPasswordResetCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
