using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Results;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetStudentsCountPerDepartmentQuery : IRequest<Response<IEnumerable<GetStudentsCountPerDepartmentResponse>>>
    {
    }
}
