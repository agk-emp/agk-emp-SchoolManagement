using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers
{
    public class InstructorsQueryHandler : ResponseHandler,
        IRequestHandler<GetInstructorsTotalSalariesQuery, Response<decimal>>
    {
        private readonly IInstructorService _instructorService;
        public InstructorsQueryHandler(IStringLocalizer<SharedResources> localizer,
            IInstructorService instructorService) : base(localizer)
        {
            _instructorService = instructorService;
        }

        public async Task<Response<decimal>> Handle(GetInstructorsTotalSalariesQuery request, CancellationToken cancellationToken)
        {
            var result = _instructorService.GetInstructorsTotalSalaries();
            return Success(result);
        }
    }
}