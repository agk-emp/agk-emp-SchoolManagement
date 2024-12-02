using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        [FromRoute]
        public int id { get; set; }
        public DeleteRoleCommand(int id)
        {
            this.id = id;
        }
    }
}
