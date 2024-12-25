
namespace SchoolProject.Service.Abstracts
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string message, string? reason = null);
    }
}
