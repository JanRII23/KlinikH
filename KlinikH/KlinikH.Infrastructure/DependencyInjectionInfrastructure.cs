using KlinikH.Infrastructure.Repositories.Implementations;
using KlinikH.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using KlinikH.Infrastructure.Repositories;

namespace KlinikH.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<UnitOfWorkInterface, UnitOfWork>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();

            return services;
        }
    }
}
