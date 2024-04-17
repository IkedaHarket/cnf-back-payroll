using Backend.ProyectName.API.Persistence.Interfaces;
using Backend.ProyectName.API.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.ProyectName.API.Bootstrapper
{
    public static class PersistenceExtension
    {
        public static IServiceCollection RegisterRepositoryExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataBaseNameRepository, DataBaseNameRepository>();
            return services;
        }
    }
}