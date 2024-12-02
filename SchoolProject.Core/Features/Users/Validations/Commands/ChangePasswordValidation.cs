using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Validations.Commands
{
    public class ChangePasswordValidation : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ChangePasswordValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            AddCommonRules();
        }

        public void AddCommonRules()
        {
            RuleFor(x => x.ChangeUserPasswordBody.CurrentPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.Password]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.Password]]);
            RuleFor(x => x.ChangeUserPasswordBody.NewPassword)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Password]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Password]]);
            RuleFor(x => x.ChangeUserPasswordBody.ConfirmPassword)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Password]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Password]]);

            RuleFor(x => x.ChangeUserPasswordBody.ConfirmPassword)
                .Equal(x => x.ChangeUserPasswordBody.NewPassword)
                .WithMessage(_localizer[SharedResourcesKeys.MustEqual,
                SharedResourcesKeys.Password,
                SharedResourcesKeys.ConfirmPassword]);
        }
    }
}
