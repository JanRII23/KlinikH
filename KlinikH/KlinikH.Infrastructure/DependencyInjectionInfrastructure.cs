using KlinikH.Infrastructure.Repositories.Implementations;
using KlinikH.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using KlinikH.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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

            //TODO: this is defining a global authorization as deny by default for all controller actions need special handling if allowed to be public facing
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
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
