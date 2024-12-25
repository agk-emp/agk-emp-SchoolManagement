using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Service.Requests;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class RegisterUserCommand : RegisterUserRequest, IRequest<Response<string>>
    {
    }
}
