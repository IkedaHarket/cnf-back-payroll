using Backend.Payroll.API.Application.DTO.Request;
using Backend.Payroll.API.Application.DTO.Response;
using Backend.Payroll.API.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Application.Interfaces
{
    public interface IPayrollBusiness
    {
        Task<HealthCheckResponse> HealthCheck();
        Task<PayrollDocument> SendPayroll(IFormFile file);
        Task<PayrollDocument> GetPayroll(GetPayrollStatusRequest request);
        Task<IEnumerable<Settlement>> GetSettlements(GetSettlementsRequest request);

    }
}
