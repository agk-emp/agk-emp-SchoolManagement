using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(string location, IFormFile file)
        {
            if (file.Length > 0)
            {
                try
                {


                    var path = _webHostEnvironment.WebRootPath + "/" + location + "/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;

                    using (FileStream fs = File.Create(path + fileName))
                    {
                        await fs.CopyToAsync(fs);
                        return location + "/" + fileName;
                    }
                }
                catch
                {
                    return SharedResourcesKeys.FileUploadingFailed;
                }
            }
            else
            {
                return SharedResourcesKeys.NoFile;
            }
        }
    }
}