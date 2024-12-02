using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Results;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetAllStudentsQuery:IRequest<Response<List<GetStudentList>>>
    {
    }
}
