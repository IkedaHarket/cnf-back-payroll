using Backend.Payroll.API.Domain.Models;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Infraestructure.Interfaces
{
    public interface IBankPayrollService
    {
        Task<bool> HealthCheck();
        Task<PayrollDocument> SendPayroll(PayrollDocument payroll);
        Task<PayrollDocument> GetPayroll(PayrollDocument payroll);
        Task<Settlement> GetSettlements(Settlement settlement);
    }
}
