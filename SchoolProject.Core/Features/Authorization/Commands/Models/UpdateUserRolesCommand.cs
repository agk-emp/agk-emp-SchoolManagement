using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Service.Requests;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRoles,
        IRequest<Response<string>>
    {

    }
}
