using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SchoolProject.Service.Options
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        void IConfigureOptions<JwtOptions>.Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName)
                .Bind(options);
        }
    }
}
