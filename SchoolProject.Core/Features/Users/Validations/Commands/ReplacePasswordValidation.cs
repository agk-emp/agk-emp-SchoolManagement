using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Validations.Commands
{
    public class ReplacePasswordValidation : AbstractValidator<ReplacePasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ReplacePasswordValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public void AddCommonRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]]);
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.NewPassword]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.NewPassword]]);
            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.ConfirmNewPassword]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                _localizer[SharedResourcesKeys.ConfirmNewPassword]]);

            RuleFor(x => x.ConfirmNewPassword)
                .Equal(x => x.NewPassword)
                .WithMessage(_localizer[SharedResourcesKeys.MustEqual,
                SharedResourcesKeys.NewPassword,
                SharedResourcesKeys.ConfirmNewPassword]);
        }
    }
}