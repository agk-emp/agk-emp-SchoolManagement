using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.TabledFunctions;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileService _fileService;

        public InstructorService(IInstructorRepository instructorRepository, IFileService fileService)
        {
            _instructorRepository = instructorRepository;
            _fileService = fileService;
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

        public async Task<string> AddInstructor(Instructor instructor,
            IFormFile file)
        {
            var instructorImage = await _fileService.UploadFile("instructors", file);
            if (instructorImage == SharedResourcesKeys.NoFile ||
                instructorImage == SharedResourcesKeys.FileUploadingFailed)
            {
                return instructorImage;
            }

            switch (instructorImage)
            {
                case SharedResourcesKeys.NoFile: return SharedResourcesKeys.NoFile;
                case SharedResourcesKeys.FileUploadingFailed: return SharedResourcesKeys.FileUploadingFailed;
            }
            instructor.Image = instructorImage;
            await _instructorRepository.AddAsync(instructor);
            return SharedResourcesKeys.Success;
        }
    }
}