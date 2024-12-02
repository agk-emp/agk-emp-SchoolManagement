using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetUsersWithRolesCheckingQuery : IRequest<Response<UserWithRolesAvailability>>
    {
        [FromRoute]
        public int id { get; set; }
    }
}
