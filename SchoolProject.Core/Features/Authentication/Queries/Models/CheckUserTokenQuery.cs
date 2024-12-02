using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Queries.Models
{
    public class CheckUserTokenQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
