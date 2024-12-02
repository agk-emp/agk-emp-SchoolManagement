using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtResult>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtResult>>
    {
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> localizer,
            UserManager<User> userManager, SignInManager<User> signInManager,
            IAuthService authService) : base(localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        public async Task<Response<JwtResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            var result = await _signInManager.CheckPasswordSignInAsync(
                user, request.Password, false);

            var accessToken = await _authService.GetJwtToken(user);
            return Success(accessToken);
        }

        public async Task<Response<JwtResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var refTok = await _authService.RefreshToken(request.AccessToken,
                    request.RefreshToken);

                return Success(refTok);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity<JwtResult>(ex.Message.ToString());
            }
        }
    }
}