using Backend.Payroll.API.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Payroll.API.Domain.Models;
using Backend.Payroll.API.Persistence.Interfaces;
using Backend.Payroll.API.Infraestructure.Interfaces;
using Backend.Payroll.API.Application.DTO.Request;
using System.Collections.Generic;
using Backend.Payroll.API.Application.DTO.Response;
using Mapster;

namespace Backend.Payroll.API.Application.Business
{
    public class PayrollBusiness(
        IPayrollRepository _payrollRepository,
        IBankPayrollService _bankPayrollService
        ) : IPayrollBusiness
    {
        public async Task<PayrollDocument> GetPayroll(GetPayrollStatusRequest request)
        {
            var payrollDocument = request.Adapt<PayrollDocument>();
            var payrollStatus = await _bankPayrollService.GetPayroll(payrollDocument);

            return payrollStatus;
        }

        public async Task<IEnumerable<Settlement>> GetSettlements(GetSettlementsRequest request)
        {
            var settlement = request.Adapt<Settlement>();
            var settlements = await _bankPayrollService.GetSettlements(settlement);

            return new List<Settlement> { settlements };

        }

        public async Task<HealthCheckResponse> HealthCheck()
        {
            var bankHealth = await _bankPayrollService.HealthCheck();
            return new HealthCheckResponse
            {
                Backend = true,
                BancoEstado = bankHealth
            };
        }

        public async Task<PayrollDocument> SendPayroll(IFormFile file)
        {
            try
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                byte[] fileBytes = stream.ToArray();

                var newDocument = new PayrollDocument
                {
                    Id = Guid.NewGuid(),
                    Content = fileBytes,
                    CreatedAt = DateTime.UtcNow
                };

                var payrollDocument = await _bankPayrollService.SendPayroll(newDocument);


                await _payrollRepository.SaveFile(payrollDocument);

                return payrollDocument;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
