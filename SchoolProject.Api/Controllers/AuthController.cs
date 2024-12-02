using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    public class AuthController : AppControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Routing.LoginRouting.Login)]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost(Routing.LoginRouting.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet(Routing.LoginRouting.CheckUserTokenValidity)]
        public async Task<IActionResult> CheckUserTokenValidity([FromQuery] CheckUserTokenQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }
    }
}