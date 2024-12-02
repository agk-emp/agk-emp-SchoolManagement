using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Validations.Commands
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
    {
        private readonly IStringLocalizer _localizer;

        public RegisterUserValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            AddUserCommonRules();
        }

        private void AddUserCommonRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.FullName]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.FullName]])
                .MaximumLength(SharedResourcesKeys.userNameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength,
                SharedResourcesKeys.userNameMaxLength]);
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.User]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.User]])
                .MaximumLength(SharedResourcesKeys.userNameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength,
                SharedResourcesKeys.userNameMaxLength]);
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]]);
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Password]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Password]]);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage(_localizer[SharedResourcesKeys.MustEqual,
                SharedResourcesKeys.Password,
                SharedResourcesKeys.ConfirmPassword]);
        }
    }
}