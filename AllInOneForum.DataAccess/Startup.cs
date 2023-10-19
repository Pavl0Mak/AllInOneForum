using AllInOneForum.DataAccess.Contracts.Interfaces;
using AllInOneForum.DataAccess.Contracts.DataContext;
using AllInOneForum.DataAccess.Repo;
using Microsoft.Extensions.DependencyInjection;
using AllInOneForum.DataAccess.Contracts.UnitOfWork;

namespace AllInOneForum.DataAccess
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<EntitiesDBContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
