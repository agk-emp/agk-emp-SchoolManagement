using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Infrastructure.Resources;

namespace SchoolProject.Core.Features.Email.Commands.Validations
{
    public class SendEmailValidation : AbstractValidator<SendEmailCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public SendEmailValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            AddCommonRules();
        }

        private void AddCommonRules()
        {
            RuleFor(stud => stud.Email).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Email]]).
           NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Email]])
           .Matches(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$")
            .WithMessage(SharedResourcesKeys.InvalidEmailAddress);

            RuleFor(stud => stud.Message).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Message]]).
           NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.Message]]);
        }
    }
}
