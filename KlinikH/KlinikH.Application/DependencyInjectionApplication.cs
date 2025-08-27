using KlinikH.Application.Services;
using KlinikH.Application.Services.Interfaces;
using KlinikH.Infrastructure.Repositories;
using KlinikH.Infrastructure.Repositories.Implementations;
using KlinikH.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KlinikH.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AppUserServiceInterface, AppUserService>();
            services.AddTransient<UnitOfWorkInterface, UnitOfWork>();
            services.AddScoped<DbInitializerInterface, DbInitializerService>();

            //NOTE: does this need to be here?
            /*services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DevConnection")));
*/
            return services;
        }
    }
}
