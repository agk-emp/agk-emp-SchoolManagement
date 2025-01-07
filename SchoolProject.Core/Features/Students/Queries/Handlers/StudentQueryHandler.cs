using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentList>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetStudentById>>,
        IRequestHandler<GetStudentsPaginatedQuery, PaginatedResponse<GetStudentsPaginated>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetStudentList>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var mappedStudents = _mapper.Map<List<GetStudentList>>(students);
            return Success(mappedStudents, new { Count = students.Count });
        }

        public async Task<Response<GetStudentById>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentById(request.Id);
            if (student is null)
            {
                return NotFound<GetStudentById>();
            }
            var mappedStudent = _mapper.Map<GetStudentById>(student);
            return Success(mappedStudent);
        }

        public async Task<PaginatedResponse<GetStudentsPaginated>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentsPaginated>> mappingSql = e => new GetStudentsPaginated(
            //    e.StudID, e.GetLocalizedName(e.NameAr, e.NameEn), e.Address, e.Department.GetLocalizedName(e.Department.DNameAr, e.Department.DNameEn));

            var studentsFiltered = _studentService.FilterStudents(request.Search,
                request.OrderBy);

            var query = await _mapper.ProjectTo<GetStudentsPaginated>(studentsFiltered)
                .ToPaginatedResult(request.PageNumber,
                request.PageSize);

            query.Meta = new { CurrentPageCount = query.TotalCount };

            return query;
        }
    }
}
