using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Validations.Commands
{
    public class UpdateUserValidation : AbstractValidator<EditUserCommand>
    {
        public IStringLocalizer<SharedResources> _localizer { get; set; }
        public UserManager<User> _userManager { get; set; }
        public UpdateUserValidation(IStringLocalizer<SharedResources> localizer,
            UserManager<User> userManager)
        {
            _localizer = localizer;
            _userManager = userManager;
            CommonRules();
            CustomRules();
        }

        private void CommonRules()
        {
            RuleFor(x => x.EditUserBody.FullName)
              .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
              _localizer[SharedResourcesKeys.FullName]])
              .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
              _localizer[SharedResourcesKeys.FullName]])
              .MaximumLength(SharedResourcesKeys.userNameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength,
              SharedResourcesKeys.userNameMaxLength]);

            RuleFor(x => x.EditUserBody.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.User]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.User]])
                .MaximumLength(SharedResourcesKeys.userNameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength,
                SharedResourcesKeys.userNameMaxLength]);

            RuleFor(x => x.EditUserBody.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]]);
        }

        private void CustomRules()
        {
            CheckForUsername();
            CheckForFullname();
            CheckForFullname();
        }

        private void CheckForUsername()
        {
            RuleFor(x => x.EditUserBody.UserName)
                .MustAsync(async (model, key, cancellationToken) =>
                {
                    return await _userManager.Users.Where(usr =>
                    usr.Id != model.id)
                    .FirstOrDefaultAsync(x => x.FullName == key) is null;
                }).WithMessage(_localizer[SharedResourcesKeys.AlreadyExists,
                SharedResourcesKeys.PropertyValue]);
        }

        private void CheckForEmail()
        {
            RuleFor(x => x.EditUserBody.Email)
                .MustAsync(async (model, key, CancellationToken) =>
                await _userManager.Users.Where(usr =>
                usr.Id != model.id)
                .FirstOrDefaultAsync(x => x.Email == key) is null)
                .WithMessage(_localizer[SharedResourcesKeys.AlreadyExists,
                SharedResourcesKeys.PropertyValue]);
        }

        private void CheckForFullname()
        {
            RuleFor(x => x.EditUserBody.FullName)
                .MustAsync(async (model, key, cancellationToken) =>
                {
                    return await _userManager.Users.Where(usr =>
                    usr.Id != model.id)
                    .FirstOrDefaultAsync(x => x.FullName == key) is null;
                }).WithMessage(_localizer[SharedResourcesKeys.AlreadyExists,
                SharedResourcesKeys.PropertyValue]);
        }
    }
}
