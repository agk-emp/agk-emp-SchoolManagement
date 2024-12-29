using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Core.Features.Instructors.Queries.Results;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers
{
    public class InstructorsQueryHandler : ResponseHandler,
        IRequestHandler<GetInstructorsTotalSalariesQuery, Response<decimal>>,
        IRequestHandler<GetInstructorsDetailsQuery, Response<IQueryable<GetInstructorsDetailsResponse>>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorsQueryHandler(IStringLocalizer<SharedResources> localizer,
            IInstructorService instructorService,
            IMapper mapper) : base(localizer)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        public async Task<Response<decimal>> Handle(GetInstructorsTotalSalariesQuery request, CancellationToken cancellationToken)
        {
            var result = _instructorService.GetInstructorsTotalSalaries();
            return Success(result);
        }

        public Task<Response<IQueryable<GetInstructorsDetailsResponse>>> Handle(GetInstructorsDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = _instructorService.GetInstructorsDetails();
            var mappedResult = _mapper.ProjectTo<GetInstructorsDetailsResponse>(result);
            return Task.FromResult(Success(mappedResult));
        }
    }
}