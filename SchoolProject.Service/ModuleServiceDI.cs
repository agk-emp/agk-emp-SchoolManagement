﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.AuthenticationServices.Abstracts;
using SchoolProject.Service.AuthenticationServices.Implementations;
using SchoolProject.Service.Implementations;
using SchoolProject.Service.Options;
using System.Text;

namespace SchoolProject.Service
{
    public static class ModuleServiceDI
    {
        public static IServiceCollection AddServiceDIS(this IServiceCollection services)
        {
            ConfigureOptions(services);

            CheckJwt(services);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            AddAuthorizationSettings(services);

            services.AddTransient<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            RegisterServices(services);

            return services;
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IClaimService, ClaimService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IInstructorService, InstructorService>();
        }

        private static void ConfigureOptions(IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<RefreshTokenOptionsSetup>();
            services.ConfigureOptions<EmailOptionsSetup>();
        }

        private static void CheckJwt(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var jwtSettings = provider.GetRequiredService<IOptions<JwtOptions>>().Value;

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero,
            };

            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
         .AddJwtBearer(x =>
         {
             x.RequireHttpsMetadata = false;
             x.SaveToken = true;
             x.TokenValidationParameters = tokenValidationParameters;
         });
        }

        private static void AddAuthorizationSettings(IServiceCollection services)
        {
            services.AddAuthorization(option =>
            {
                option.AddPolicy("DeleteStudent", pol =>
                {
                    pol.RequireClaim("delete", "delete");
                });
            });
        }
    }
}
