using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Results;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; } = 1;
        public int StudentPageSize { get; set; } = 10;
    }
}
