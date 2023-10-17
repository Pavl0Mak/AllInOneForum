using AllInOneForum.DataAccess.Contracts.Interfaces;
using AllInOneForum.DataAccess.DataContext;
using AllInOneForum.DataAccess.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace AllInOneForum.DataAccess
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<EntitiesDBContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
