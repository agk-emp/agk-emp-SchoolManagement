using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    public class UserController : AppControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Routing.UserRouting.Register)]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Routing.UserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Routing.UserRouting.GetAll)]
        public async Task<IActionResult> GetUsersPaginated(
            [FromQuery] GetUsersPaginatedQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [HttpPut(Routing.UserRouting.Update)]
        public async Task<IActionResult> UpdateUser(EditUserCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete(Routing.UserRouting.Delete)]
        public async Task<IActionResult> DeleteUser([FromRoute] DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut(Routing.UserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet(Routing.UserRouting.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }
    }
}
