using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        [FromRoute]
        public int id { get; set; }

        [FromBody]
        public EditUserCommandBody EditUserBody { get; set; }
    }
}
