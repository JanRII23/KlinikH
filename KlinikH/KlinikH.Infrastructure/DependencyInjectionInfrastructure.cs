using KlinikH.Infrastructure.Repositories.Implementations;
using KlinikH.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using KlinikH.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using KlinikH.Domain.Entities;

namespace KlinikH.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<UnitOfWorkInterface, UnitOfWork>();
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<ApplicationDBContext>();

            //NOTE: this is defining a global authorization as deny by default for all controller actions need special handling if allowed to be public facing
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //NOTE: at this time this is actually only configured for the User side of things need the admin but still needs to be identity user just need to map type
            services.ConfigureApplicationCookie(config =>
            {
                config.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Redirect("/User/Account/Login?returnUrl=" + context.Request.Path);
                    return Task.CompletedTask;
                };
            });
            //NOTE: like so there are actually other things you can customize in identities just check docs or under IdentityOptions. above is just the shorthand for it
            /*services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            });*/

            return services;
        }
    }
}
