using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers
{
    public class InstructorCommandsHandler : ResponseHandler,
        IRequestHandler<AddInstructorCommand, Response<string>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorCommandsHandler(IStringLocalizer<SharedResources> localizer,
            IMapper mapper,
            IInstructorService instructorService) : base(localizer)
        {
            _mapper = mapper;
            _instructorService = instructorService;
        }

        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructor(instructor,
                request.Image);

            switch (result)
            {
                case SharedResourcesKeys.NoFile:
                    return UnprocessableEntity<string>(SharedResourcesKeys.NoFile);
                case SharedResourcesKeys.FileUploadingFailed:
                    return UnprocessableEntity<string>(SharedResourcesKeys.FileUploadingFailed);
            }

            return Success(result);
        }
    }
}
