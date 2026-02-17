using System.Threading.Tasks;

namespace Backend.Payroll.API.Persistence.Interfaces
{
    public interface ILogRepository
    {
        Task<bool> SaveLog();
    }
}
