using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helper;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedQuery : IRequest<PaginatedResponse<GetStudentsPaginated>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public StudentOrderingEnum? OrderBy { get; set; }
    }
}
