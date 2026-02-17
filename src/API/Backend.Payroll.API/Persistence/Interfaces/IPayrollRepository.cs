using Backend.Payroll.API.Domain.Models;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Persistence.Interfaces
{
    public interface IPayrollRepository
    {
        Task<PayrollDocument> SaveFile(PayrollDocument payrollDocument);
    }
}
