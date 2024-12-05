using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Data.AppMeatData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AuthorizationController : AppControllerBase
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Routing.AuthorizationRouting.CreateRole)]
        public async Task<IActionResult> CreateRole([FromBody] AddRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut(Routing.AuthorizationRouting.UpdateRole)]
        public async Task<IActionResult> UpdateRole(EditRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete(Routing.AuthorizationRouting.DeleteRole)]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var command = new DeleteRoleCommand(id);
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [SwaggerOperation(summary: "Get the role by the id", OperationId = "GetRole")]
        [HttpGet(Routing.AuthorizationRouting.GetRole)]
        public async Task<IActionResult> GetRole([FromRoute] int id)
        {
            var request = new GetRoleByIdQuery();
            request.id = id;
            var result = await _mediator.Send(request);
            return NewResult(result);
        }

        [SwaggerOperation(summary: "Get all roles not paginated because we do not need that many roles")]
        [HttpGet(Routing.AuthorizationRouting.GetRoles)]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _mediator.Send(new GetRolesQuery());
            return NewResult(result);
        }

        [SwaggerOperation(summary: "Get a user with all the roles if available true otherwise false")]
        [HttpGet(Routing.AuthorizationRouting.GetUserWithRolesChecker)]
        public async Task<IActionResult> GetUserWithRolesChecked(GetUsersWithRolesCheckingQuery command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut(Routing.AuthorizationRouting.UpdateUserRoles)]
        [SwaggerOperation(summary: "Update the user with its roles")]
        public async Task<IActionResult> UpdateUserRoles(UpdateUserRolesCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet(Routing.AuthorizationRouting.ManageUserClaims)]
        [SwaggerOperation(summary: "Manage user claims")]
        public async Task<IActionResult> GetUserClaims(int id)
        {
            var result = await _mediator.Send(new ManageUserClaimsQuery(id));
            return NewResult(result);
        }

        [HttpPut(Routing.AuthorizationRouting.UpdateUserClaims)]
        [SwaggerOperation(summary: "Update user claims")]
        public async Task<IActionResult> UpdateUserClaims(UpdateUserClaimsCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
    }
}