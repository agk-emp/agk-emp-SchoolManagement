using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Email.Commands.Handlers
{
    public class EmailCommandsHandler : ResponseHandler, IRequestHandler<SendEmailCommand,
        Response<string>>
    {
        private readonly IEmailService _emailService;
        public EmailCommandsHandler(IStringLocalizer<SharedResources> localizer,
            IEmailService emailService) : base(localizer)
        {
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmail(request.Email, request.Message);
            if (result)
            {
                return Success<string>(_localizer[SharedResourcesKeys.Updated]);
            }
            return UnprocessableEntity<string>();
        }
    }
}
