using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolProject.Service.AuthenticationServices.Abstracts;

namespace SchoolProject.Core.Filters
{
    public class AuthFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserService _currentUserService;

        public AuthFilter(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var roles = await _currentUserService.GetCurrentUserRoles();
                if (!roles.Any(rl => rl == "admin"))
                {
                    context.Result = new ObjectResult("")
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
