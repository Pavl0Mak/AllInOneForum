using AllInOneForum.Services.Contracts.Interfaces;
using AllInOneForum.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AllInOneForum.Services
{
    public static class Startup
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}