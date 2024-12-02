using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        [FromRoute]
        public int id { get; set; }

        [FromBody]
        public EditStudentCommandBody EditStudentCommandBody { get; set; }
    }
}
