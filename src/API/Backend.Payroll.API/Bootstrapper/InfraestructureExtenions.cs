using System;
using Backend.Payroll.API.Infraestructure.Services;
using Backend.Payroll.API.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DTO = Backend.Payroll.API.Application.DTO;
using Backend.Payroll.API.Application.Business;

namespace Backend.Payroll.API.Bootstrapper
{
    public static class InfraestructureExtenions
    {
        public static IServiceCollection RegisterInfraestructureExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("ServiceName", client =>
            {
                client.BaseAddress = new System.Uri(configuration["Apis:UrlService"]);
            });

            services.AddTransient<IBankPayrollService, BancoEstadoPayrollService>();

            return services;
        }
    }
}