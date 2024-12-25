using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Validations.Commands
{
    public class ConfirmPasswordResetValidation : AbstractValidator<ConfirmPasswordResetCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ConfirmPasswordResetValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            AddUserCommonRules();
        }

        private void AddUserCommonRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Email]]);
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Code]])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty,
                 _localizer[SharedResourcesKeys.Code]]);
        }
    }
}
