using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SchoolProject.Service.Options
{
    public class RefreshTokenOptionsSetup : IConfigureOptions<RefreshTokenOptions>
    {
        private const string SectionName = "RefreshToken";
        private readonly IConfiguration _configuration;

        public RefreshTokenOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(RefreshTokenOptions options)
        {
            _configuration.GetSection(SectionName)
                .Bind(options);
        }
    }
}
