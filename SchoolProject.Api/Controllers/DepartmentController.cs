using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    public class DepartmentController : AppControllerBase
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Routing.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetById([FromQuery] GetDepartmentByIdQuery query)
        {
            var department = await _mediator.Send(query);
            return NewResult(department);
        }

        [HttpGet(Routing.DepartmentRouting.GetStudentsPerDepartment)]
        public async Task<IActionResult> GetStudentsPerDepartment()
        {
            var result = await _mediator.Send(new
                GetStudentsCountPerDepartmentQuery());
            return NewResult(result);
        }
    }
}
