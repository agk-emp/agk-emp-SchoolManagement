using MediatR;
using SchoolProject.Core.Features.Users.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.Models
{
    public class GetUsersPaginatedQuery : IRequest<PaginatedResponse<GetUsersPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
