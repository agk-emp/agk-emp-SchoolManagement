using SchoolProject.Data.Entities.TabledFunctions;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public decimal GetInstructorsTotalSalaries()
        {
            var result = _instructorRepository.GetInstructorsTotalSalaries();
            return result;
        }

        public IQueryable<GetInstructorsDetailsFunction> GetInstructorsDetails()
        {
            var result = _instructorRepository.GetInstructorsDetails();
            return result;
        }
    }
}