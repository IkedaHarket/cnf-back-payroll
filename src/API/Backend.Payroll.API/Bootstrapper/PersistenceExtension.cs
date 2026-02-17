using Backend.Payroll.API.Persistence.Interfaces;
using Backend.Payroll.API.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Payroll.API.Bootstrapper
{
    public static class PersistenceExtension
    {
        public static IServiceCollection RegisterRepositoryExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IPayrollRepository, PayrollRepository>();
            return services;
        }
    }
}