using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using Serilog;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetStudentsCountPerDepartmentQuery,
            Response<IEnumerable<GetStudentsCountPerDepartmentResponse>>>,
        IRequestHandler<GETStudentsCountForSpecificDepartmentQuery,
            Response<GETStudentsCountForSpecificDepartmentResponse>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> localizer,
            IDepartmentService departmentService,
            IMapper mapper,
            IStudentService studentService) : base(localizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentById(request.Id);

            if (department is null)
            {
                Log.Error("No department with this id exists");
                return NotFound<GetDepartmentByIdResponse>();
            }

            var mappedResult = _mapper.Map<GetDepartmentByIdResponse>(department);

            Expression<Func<Student, DepartmentStudents>> expression = e => new DepartmentStudents(
                e.StudID, e.GetLocalizedName(e.NameAr, e.NameEn));

            var students = _studentService.GetStudentsByDepartmentId(request.Id);
            var departmentStudentsPaginated = await students.Select(expression)
            .ToPaginatedResult(request.StudentPageNumber,
            request.StudentPageSize);

            mappedResult.Students = departmentStudentsPaginated;
            return Success(mappedResult);
        }

        public async Task<Response<IEnumerable<GetStudentsCountPerDepartmentResponse>>> Handle(GetStudentsCountPerDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetStudentsForEachDepartments();
            var mappedResult = _mapper.Map<IEnumerable<GetStudentsCountPerDepartmentResponse>>(result);
            return Success(mappedResult);
        }

        public async Task<Response<GETStudentsCountForSpecificDepartmentResponse>> Handle(GETStudentsCountForSpecificDepartmentQuery request, CancellationToken cancellationToken)
        {
            var procResult = await _departmentService.GetStudentsCountForThisDepartment(request.Id);
            var mappedResult = _mapper.Map<GETStudentsCountForSpecificDepartmentResponse>(procResult);
            return Success(mappedResult);
        }
    }
}