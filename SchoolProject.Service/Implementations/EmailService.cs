using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Options;

namespace SchoolProject.Service.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;

        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        //To do localizing messages
        public async Task<bool> SendEmail(string email,
            string message, string? reason = null)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailOptions.SmtpServer, _emailOptions.Port, true);
                    await client.AuthenticateAsync(_emailOptions.From,
                        _emailOptions.Password);

                    var bodyBuilder = new BodyBuilder()
                    {
                        TextBody = "Welcome",
                        HtmlBody = message,
                    };

                    var emailMessage = new MimeMessage()
                    {
                        Body = bodyBuilder.ToMessageBody()
                    };

                    emailMessage.From.Add(new MailboxAddress("School team",
                        _emailOptions.From));

                    emailMessage.To.Add(new MailboxAddress(string.Empty,
                        email));

                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}