using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class AuthorizationQueryHandler : ResponseHandler,
        IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
        IRequestHandler<GetRolesQuery, Response<List<GetRolesResult>>>,
        IRequestHandler<GetUsersWithRolesCheckingQuery, Response<UserWithRolesAvailability>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        public AuthorizationQueryHandler(IStringLocalizer<SharedResources> localizer,
            IAuthorizationService authorizationService,
            IMapper mapper) : base(localizer)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetById(request.id);
            var result = _mapper.Map<GetRoleByIdResult>(roles);
            return Success(result);
        }

        public async Task<Response<List<GetRolesResult>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRoles();
            var result = _mapper.Map<List<GetRolesResult>>(roles);
            return Success(result);
        }

        public async Task<Response<UserWithRolesAvailability>> Handle(GetUsersWithRolesCheckingQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _authorizationService.GetUserWithRolesChecker(request.id);
                return Success(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity<UserWithRolesAvailability>(ex.Message);
            }
        }
    }
}
