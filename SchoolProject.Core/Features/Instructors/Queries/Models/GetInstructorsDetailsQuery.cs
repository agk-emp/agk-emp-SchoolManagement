using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Results;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorsDetailsQuery : IRequest<Response<
        IQueryable<GetInstructorsDetailsResponse>>>
    {
    }
}
