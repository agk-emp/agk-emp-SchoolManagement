using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        [FromRoute]
        public int id { get; set; }

        public ManageUserClaimsQuery(int id)
        {
            this.id = id;
        }
    }
}
