using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler, IRequestHandler<CheckUserTokenQuery,
        Response<string>>
    {
        private readonly IAuthService _authService;
        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> localizer,
            IAuthService authService) : base(localizer)
        {
            _authService = authService;
        }

        public async Task<Response<string>> Handle(CheckUserTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_authService.ValidateSignInToken(request.AccessToken));

            if (result)
            {
                return Success<string>(_localizer[SharedResourcesKeys.UserLoggedIn]);
            }
            return Unauthorized<string>();
        }
    }
}
