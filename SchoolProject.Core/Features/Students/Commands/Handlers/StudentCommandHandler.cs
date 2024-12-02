using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;

        public StudentCommandHandler(IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);

            await _studentService.AddStudent(student);
            return Created<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await GetById(request.id);
            if (studentToUpdate is null)
            {
                return NotFound<string>();
            }

            var studentUpdated = _mapper.Map(request, studentToUpdate);
            await _studentService.EditStudent(studentUpdated);
            return Success<string>(_localizer[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await GetById(request.Id);
            if (studentToDelete is null)
            {
                return NotFound<string>();
            }
            await _studentService.DeleteStudent(studentToDelete);
            return Deleted<string>();
        }

        private async Task<Student> GetById(int id)
        {
            var student = await _studentService.GetStudentWithoutInclude(id);
            return student;
        }
    }
}
