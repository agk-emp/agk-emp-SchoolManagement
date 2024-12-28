using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorsTotalSalariesQuery : IRequest<Response<decimal>>
    {
    }
}
