using KlinikH.Application.Services;
using KlinikH.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KlinikH.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services)
        {
            services.AddTransient<AppUserServiceInterface, AppUserService>();

            return services;
        }
    }
}
