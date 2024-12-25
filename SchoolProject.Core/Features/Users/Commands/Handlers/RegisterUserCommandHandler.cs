using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Users.Commands.Handlers
{
    public class RegisterUserCommandHandler : ResponseHandler,
        IRequestHandler<RegisterUserCommand, Response<string>>,
        IRequestHandler<EditUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>,
        IRequestHandler<ConfirmPasswordResetCommand, Response<string>>,
        IRequestHandler<ReplacePasswordCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IStringLocalizer<SharedResources> localizer,
            IMapper mapper,
            UserManager<User> userManager,
            IAuthorizationService authorizationService,
            IAuthService authService) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _authService = authService;
        }

        public async Task<Response<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await _authService.RegisterUser(request);
                return Created<string>();
            }
            catch (Exception ex)
            {

                return Failure<string>(_localizer[ex.Message]);
            }
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id.ToString());
            if (user is null)
            {
                return NotFound<string>();
            }

            var updatedUser = _mapper.Map(request, user);
            await _userManager.UpdateAsync(updatedUser);
            return Success<string>(_localizer[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id.ToString());

            if (user is null)
            {
                return NotFound<string>();
            }
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
            }
            return Success<string>(_localizer[SharedResourcesKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id.ToString());
            if (user is null)
            {
                return NotFound<string>();
            }


            var result = await _userManager.ChangePasswordAsync(user,
                request.ChangeUserPasswordBody.CurrentPassword,
                request.ChangeUserPasswordBody.NewPassword);

            if (result.Succeeded)
            {
                return Success<string>(SharedResourcesKeys.Updated);
            }

            return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPassword(request.Email);
            if (result)
            {
                return Success(SharedResourcesKeys.Updated);
            }
            return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
        }

        public async Task<Response<string>> Handle(ConfirmPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ConfirmPasswordResetting(request.Email,
                request.Code);

            if (result)
            {
                return Success(SharedResourcesKeys.Success);
            }
            return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
        }

        public async Task<Response<string>> Handle(ReplacePasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ReplacePassword(request.Email, request.NewPassword);
            if (result)
            {
                return Success(SharedResourcesKeys.Success);
            }
            return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
        }
    }
}
