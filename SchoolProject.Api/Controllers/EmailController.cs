using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    public class EmailController : AppControllerBase
    {
        public EmailController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Routing.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail(SendEmailCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
    }
}
