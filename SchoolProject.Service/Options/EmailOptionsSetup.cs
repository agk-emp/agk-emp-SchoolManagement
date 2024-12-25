using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SchoolProject.Service.Options
{
    public class EmailOptionsSetup : IConfigureOptions<EmailOptions>
    {
        private readonly string SectionName = "Email";
        private readonly IConfiguration _configuration;

        public EmailOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(EmailOptions options)
        {
            _configuration.GetSection(SectionName)
                .Bind(options);
        }
    }
}