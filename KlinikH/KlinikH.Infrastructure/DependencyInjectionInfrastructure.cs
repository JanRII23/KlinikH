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
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<ApplicationDBContext>();

            //TODO: like so there are actually other things you can customize in identities just check docs or under IdentityOptions. above is just the shorthand for it
            /*services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            });*/

            return services;
        }
    }
}
