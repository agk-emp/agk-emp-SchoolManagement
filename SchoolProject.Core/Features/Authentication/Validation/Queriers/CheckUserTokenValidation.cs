using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Authentication.Validation.Queriers
{
    public class CheckUserTokenValidation : AbstractValidator<CheckUserTokenQuery>
    {
        private IStringLocalizer<SharedResources> _localizer;
        public CheckUserTokenValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        private void AddCommonRules()
        {
            RuleFor(user => user.AccessToken).
              NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.AccessToken]])
              .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.AccessToken]]);
        }
    }
}
