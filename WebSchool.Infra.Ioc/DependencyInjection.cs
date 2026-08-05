using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.Interfaces;
using WebSchool.Application.Services;
using WebSchool.Domain.Account;
using WebSchool.Domain.Interfaces;
using WebSchool.Infra.Data.Context;
using WebSchool.Infra.Data.Identity;
using WebSchool.Infra.Data.Repositories;

namespace WebSchool.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraesctructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext> (options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITuitionRepository, TuitionRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITuitionService, TuitionService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ISchoolClassService, SchoolClassService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticate, AuthenticateProvider>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            return services;
        }
    }
}
