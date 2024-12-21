using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Authentication.Validation.Commands
{
    public class SignInValidation : AbstractValidator<SignInCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public SignInValidation(IStringLocalizer<SharedResources> localizer,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _localizer = localizer;
            _signInManager = signInManager;
            _userManager = userManager;

            AddCommonValidators();
            AddCustomValidators();
        }

        private void AddCommonValidators()
        {
            RuleFor(user => user.UserName).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.User]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.User]]);

            RuleFor(user => user.Password).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Password]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Password]]);
        }

        private void AddCustomValidators()
        {
            RuleFor(user => user.UserName)
                .MustAsync(async (key, cancellationToken) =>
                    await DoesUserExist(key))
            .WithMessage(_localizer[SharedResourcesKeys.NotFound]);

            RuleFor(user => user.Password)
                .MustAsync(async (model, key, cancellationToken) =>
                await CheckPassword(key, model.UserName))
            .WithMessage(_localizer[SharedResourcesKeys.UserNameOrPasswordAreInCorrect]);
        }

        private async Task<bool> DoesUserExist(string userName)
        {
            if (await _userManager.FindByNameAsync(userName) is null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> CheckPassword(string password,
            string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = await _signInManager.CheckPasswordSignInAsync(user,
                password, false);

            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
