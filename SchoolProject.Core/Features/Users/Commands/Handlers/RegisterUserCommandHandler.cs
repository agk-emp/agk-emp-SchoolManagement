using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Commands.Handlers
{
    public class RegisterUserCommandHandler : ResponseHandler,
        IRequestHandler<RegisterUserCommand, Response<string>>,
        IRequestHandler<EditUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public RegisterUserCommandHandler(IStringLocalizer<SharedResources> localizer,
            IMapper mapper,
            UserManager<User> userManager,
            IAuthorizationService authorizationService) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByEmailAsync(request.Email) is not null ||
                await _userManager.FindByNameAsync(request.UserName) is not null)
            {
                return Failure<string>(_localizer[SharedResourcesKeys.AlreadyExists,
                    _localizer[SharedResourcesKeys.User]]);
            }

            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                return Created<string>();
            }

            return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
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
    }
}
