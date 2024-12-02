using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : IRequest<Response<string>>
    {
        [FromRoute]
        public int id { get; set; }
        [FromBody]
        public EditRoleBody RoleBodyUpdate { get; set; }

        public class EditRoleBody
        {
            public string Name { get; set; }
        }
    }
}
