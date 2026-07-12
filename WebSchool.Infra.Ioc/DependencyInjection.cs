using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Interfaces;
using WebSchool.Infra.Data.Context;
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

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITuitionRepository, TuitionRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            

            return services;
        }
    }
}
