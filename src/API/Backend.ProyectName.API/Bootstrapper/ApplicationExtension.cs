using Backend.ProyectName.API.Application.Business;
using Backend.ServiceName.API.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.ProyectName.API.Bootstrapper
{
    public static class ApplicationExtension
    {
        public static IServiceCollection RegisterApplicationExtension(this IServiceCollection services)
        {
            services.AddTransient<IDataBusiness, DataBusiness>();
			services.AddTransient<IAuthenticateBusiness, AuthenticateBusiness>();

            return services;
        }
    }
}