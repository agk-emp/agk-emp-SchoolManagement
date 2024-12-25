using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviours;
using SchoolProject.Core.Filters;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDI
    {
        public static IServiceCollection AddCoreDIS(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehaviour<,>));

            services.AddTransient<AuthFilter>();

            return services;
        }
    }
}
