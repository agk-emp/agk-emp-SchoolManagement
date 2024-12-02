using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Validations.Commands
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;
        public AddRoleValidator(IStringLocalizer<SharedResources> localizer,
            IAuthorizationService authorizationService)
        {
            _localizer = localizer;
            _authorizationService = authorizationService;
            AddCommonRules();
            AddCustomRules();
        }

        private void AddCommonRules()
        {
            RuleFor(role => role.RoleName).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.RoleName]])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.RoleName]]);

        }

        private void AddCustomRules()
        {
            RuleFor(role => role.RoleName)
                .MustAsync(async (key, CancellationToken) =>
                !await _authorizationService.DoesRoleExist(key))
                .WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);
        }
    }
}
