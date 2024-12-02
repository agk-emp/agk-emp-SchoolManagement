using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Infrastructure.Factory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(),
                "../SchoolProject.Api");
            var optionsBuilder=new DbContextOptionsBuilder<ApplicationDbContext>();
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(basePath)  // Set the base path to the WebAPI project
                 .AddJsonFile("appsettings.json")  // Load the appsettings.json file
                 .Build();

            var connection = configuration.GetConnectionString("dbcontext");

            optionsBuilder.UseSqlServer(connection);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
