using Backend.Payroll.API.Application.Business;
using Backend.Payroll.API.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Payroll.API.Bootstrapper
{
    public static class ApplicationExtension
    {
        public static IServiceCollection RegisterApplicationExtension(this IServiceCollection services)
        {
            services.AddTransient<IPayrollBusiness, PayrollBusiness>();
            return services;
        }
    }
}