using System;
using Backend.ProyectName.API.Infraestructure.Services;
using Backend.ProyectName.API.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DTO = Backend.ProyectName.API.Application.DTO;
using Backend.ProyectName.API.Application.Business;

namespace Backend.ProyectName.API.Bootstrapper
{
    public static class InfraestructureExtenions
    {
        public static IServiceCollection RegisterInfraestructureExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("ServiceName", client =>
            {
                client.BaseAddress = new System.Uri(configuration["Apis:UrlService"]);
            });

            services.AddTransient<ICustomerAccountService, CustomerAccountService>();
            services.AddTransient<IServiceNameService, ServiceNameService>();

            return services;
        }
    }
}