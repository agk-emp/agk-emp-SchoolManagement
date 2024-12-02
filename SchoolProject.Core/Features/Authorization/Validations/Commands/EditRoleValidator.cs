using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Authorization.Validations.Commands
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public EditRoleValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            AddCommonRules();
        }

        private void AddCommonRules()
        {
            RuleFor(role => role.id).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Id]])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Id]]);
        }
    }
}
