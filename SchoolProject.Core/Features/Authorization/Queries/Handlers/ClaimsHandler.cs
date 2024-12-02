using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class ClaimsHandler : ResponseHandler, IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>
    {
        private readonly IClaimService _claimService;
        public ClaimsHandler(IStringLocalizer<SharedResources> localizer,
            IClaimService claimService) : base(localizer)
        {
            _claimService = claimService;
        }

        public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var result = await _claimService.ManageUserClaims(request.id);
            return Success(result);
        }
    }
}
