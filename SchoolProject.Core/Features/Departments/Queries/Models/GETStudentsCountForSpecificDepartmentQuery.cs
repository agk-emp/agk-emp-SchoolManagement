using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Results;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GETStudentsCountForSpecificDepartmentQuery :
        IRequest<Response<GETStudentsCountForSpecificDepartmentResponse>>
    {
        public int Id { get; set; }

        public GETStudentsCountForSpecificDepartmentQuery(int id)
        {
            Id = id;
        }
    }
}
