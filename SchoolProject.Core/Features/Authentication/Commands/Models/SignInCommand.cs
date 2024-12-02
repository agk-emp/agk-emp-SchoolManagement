using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
