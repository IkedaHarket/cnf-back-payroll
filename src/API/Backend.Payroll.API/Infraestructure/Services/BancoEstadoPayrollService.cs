using Backend.Payroll.API.Domain.Models;
using Backend.Payroll.API.Infraestructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Infraestructure.Services
{
    public class BancoEstadoPayrollService : IBankPayrollService
    {
        public async Task<bool> HealthCheck()
        {
            await Task.Delay(100);
            return true;
        }

        public async Task<PayrollDocument> SendPayroll(PayrollDocument payroll)
        {
            await Task.Delay(100);
            return payroll;
        }

        public async Task<PayrollDocument> GetPayroll(PayrollDocument payroll)
        {
            await Task.Delay(100);
            return payroll;
        }

        public async Task<Settlement> GetSettlements(Settlement settlement)
        {
            await Task.Delay(100);
            return new Settlement
            {
                Id = settlement.Id,
                PayrollId = settlement.PayrollId ?? "10001234",
                PaymentDateFrom = settlement.PaymentDateFrom,
                PaymentDateTo = settlement.PaymentDateTo,
                AgreementNumber = settlement.AgreementNumber,
                RecipientTaxId = "12.345.678-9",
                RecipientName = "John Doe",
                BankName = "BANCOESTADO",
                AccountNumberOrDocument = "987654321",
                PaymentMethodDescription = "Abono en CuentaRUT",
                PaymentDate = DateTime.Now.ToString("dd/MM/yyyy"),
                Amount = 150000,
                Status = "Accepted",
                RejectionReason = "N/A"
            };
        }
    }
}
