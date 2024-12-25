using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Users.Validations.Commands
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ResetPasswordValidation(IStringLocalizer<SharedResources> localizer)
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
        }
    }
}
