using Backend.Payroll.API.Persistence.Interfaces;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Persistence.Repositories
{
    public class LogRepository : ILogRepository
    {
        public Task<bool> SaveLog()
        {
            throw new System.NotImplementedException();
        }
    }
}
