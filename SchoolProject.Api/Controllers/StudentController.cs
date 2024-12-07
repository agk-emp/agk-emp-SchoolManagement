using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    //[Authorize]
    public class StudentController : AppControllerBase
    {
        public StudentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Routing.StudentRouting.GetAll)]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await _mediator.Send(new GetAllStudentsQuery());
            return NewResult(response);
        }

        [HttpGet(Routing.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Routing.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent(AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Routing.StudentRouting.Update)]
        public async Task<IActionResult> EditStudent(EditStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [Authorize(policy: "DeleteStudent")]
        [HttpDelete(Routing.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand(id);
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Routing.StudentRouting.GetPaginated)]
        public async Task<IActionResult> GetStudentsPaginated([FromQuery] GetStudentsPaginatedQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }
    }
}
