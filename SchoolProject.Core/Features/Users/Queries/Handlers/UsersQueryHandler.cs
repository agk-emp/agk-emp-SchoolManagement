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

namespace SchoolProject.Core.Features.Users.Queries.Handlers
{
    public class UsersQueryHandler : ResponseHandler, IRequestHandler<GetUserByIdQuery,
        Response<GetUserByIdResponse>>,
        IRequestHandler<GetUsersPaginatedQuery,
            PaginatedResponse<GetUsersPaginatedResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UsersQueryHandler(IStringLocalizer<SharedResources> localizer,
            UserManager<User> userManager,
            IMapper mapper) : base(localizer)
        {
            _userManager = userManager;
            _mapper = mapper;
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
    }
}
