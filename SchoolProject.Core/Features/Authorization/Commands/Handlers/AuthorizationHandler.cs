using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class AuthorizationHandler : ResponseHandler,
       IRequestHandler<AddRoleCommand, Response<string>>,
       IRequestHandler<EditRoleCommand, Response<string>>,
       IRequestHandler<DeleteRoleCommand, Response<string>>,
       IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;
        public AuthorizationHandler(IStringLocalizer<SharedResources> localizer,
            IAuthorizationService authorizationService) : base(localizer)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRole(request.RoleName);
            if (result)
            {
                return Created<string>();
            }
            return UnprocessableEntity<string>();
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _authorizationService.EditRole(request.id, request.RoleBodyUpdate.Name);
                if (result)
                {
                    return Success<string>(_localizer[SharedResourcesKeys.Updated]);
                }
                return UnprocessableEntity<string>();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _authorizationService.DeleteRole(request.id);
                if (result)
                {
                    return Success<string>(_localizer[SharedResourcesKeys.Updated]);
                }
                return UnprocessableEntity<string>();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _authorizationService.UpdateUserRoles(request);
                return Success<string>(_localizer[SharedResourcesKeys.Updated]);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity<string>(ex.Message);
            }
        }
    }
}