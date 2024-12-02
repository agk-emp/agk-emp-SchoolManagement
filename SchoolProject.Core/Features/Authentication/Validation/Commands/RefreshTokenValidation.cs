using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Authentication.Validation.Commands
{
    public class RefreshTokenValidation : AbstractValidator<RefreshTokenCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public RefreshTokenValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            AddCommonRules();
        }

        private void AddCommonRules()
        {
            RuleFor(user => user.AccessToken).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.AccessToken]])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.AccessToken]]);

            RuleFor(user => user.RefreshToken).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.RefreshToken]])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.RefreshToken]]);
        }
    }
}
