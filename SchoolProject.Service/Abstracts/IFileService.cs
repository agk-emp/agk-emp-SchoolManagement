using Microsoft.AspNetCore.Http;

namespace SchoolProject.Service.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadFile(string location, IFormFile formFile);
    }
}