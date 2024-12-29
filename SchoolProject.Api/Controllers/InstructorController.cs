using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : AppControllerBase
    {
        public InstructorController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Routing.InstructorRouting.GetTotalSalaries)]
        public async Task<ActionResult<Response<decimal>>> GetTotalSalaries()
        {
            var result = await _mediator.Send(new GetInstructorsTotalSalariesQuery());
            return NewResult(result);
        }

        [HttpGet(Routing.InstructorRouting.GetInstructorsDetails)]
        public async Task<IActionResult> GetInstructorsDetails()
        {
            var result = await _mediator.Send(new GetInstructorsDetailsQuery());
            return NewResult(result);
        }
    }
}