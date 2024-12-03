using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class ClaimsCommandHandler : ResponseHandler,
        IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        private readonly IClaimService _claimService;
        public ClaimsCommandHandler(IStringLocalizer<SharedResources> localizer,
            IClaimService claimService) : base(localizer)
        {
            _claimService = claimService;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            await _claimService.UpdateUserClaims(request);
            return Success<string>(_localizer[SharedResourcesKeys.Updated]);
        }
    }
}
