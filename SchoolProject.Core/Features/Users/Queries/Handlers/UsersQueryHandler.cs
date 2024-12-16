using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Core.Features.Users.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Users.Queries.Handlers
{
    public class UsersQueryHandler : ResponseHandler, IRequestHandler<GetUserByIdQuery,
        Response<GetUserByIdResponse>>,
        IRequestHandler<GetUsersPaginatedQuery,
            PaginatedResponse<GetUsersPaginatedResponse>>,
        IRequestHandler<ConfirmEmailQuery, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public UsersQueryHandler(IStringLocalizer<SharedResources> localizer,
            UserManager<User> userManager,
            IMapper mapper,
            IAuthService authService) : base(localizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user is null)
            {
                return NotFound<GetUserByIdResponse>();
            }

            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }

        public async Task<PaginatedResponse<GetUsersPaginatedResponse>> Handle(GetUsersPaginatedQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();

            var mappedUsers = _mapper.ProjectTo<GetUsersPaginatedResponse>(users);
            var result = await mappedUsers.ToPaginatedResult(request.PageNumber, request.PageSize);

            return result;
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            if (await _authService.ConfirmEmail(request.UserId, request.Code))
            {
                return Success<string>(_localizer[SharedResourcesKeys.Success]);
            }
            return Failure<string>(_localizer[SharedResourcesKeys.Unprocessable]);
        }
    }
}
