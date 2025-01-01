using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Abstracts.Views;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Repositories;
using SchoolProject.Infrastructure.Repositories.Procedures;
using SchoolProject.Infrastructure.Repositories.Views;
using Serilog;
using System.Globalization;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDIS(this IServiceCollection services,
            IConfigurationManager configuration)
        {
            services.AddDbContextFactory<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("dbcontext"));
            });

            services.AddEndpointsApiExplorer();

            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration).CreateLogger();
            services.AddSerilog();


            services.AddIdentityApiEndpoints<User>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;
            }).AddRoles<Role>()
             .AddRoleManager<RoleManager<Role>>()
             .AddSignInManager<SignInManager<User>>()
        .AddDefaultUI()
        .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<>),
                typeof(GenericRepository<>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectsRepository, SubjectsRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IUserRefrshTokenRepository, UserRefrshTokenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClaimRepository, ClaimRepository>();

            //Views
            services.AddTransient<IStudentsCountPerDepartmentViewRepository,
                StudentsCountPerDepartmentViewRepository>();

            //Stored procedures
            services.AddTransient<IStoredProceduresRepository,
                StoredProceduresRepository>();

            services.AddLocalization(opt => { opt.ResourcesPath = ""; });
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var cultures = new List<CultureInfo>()
                {
                    new CultureInfo("ar-EG"),
                    new CultureInfo("en-US")
                };

                opt.SupportedCultures = cultures;
                opt.SupportedUICultures = cultures;

                opt.RequestCultureProviders = new List<IRequestCultureProvider>()
        {
            new QueryStringRequestCultureProvider(),
            new CookieRequestCultureProvider(),
            new AcceptLanguageHeaderRequestCultureProvider()
        };
            });
            return services;
        }
    }
}
