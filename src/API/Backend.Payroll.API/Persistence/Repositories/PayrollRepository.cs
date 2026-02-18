using Backend.Payroll.API.Domain.Exceptions;
using Backend.Payroll.API.Domain.Models;
using Backend.Payroll.API.Persistence.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Persistence.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly string _payrollDb;
        public PayrollRepository(IConfiguration configuration)
        {
            _payrollDb = configuration.GetConnectionString("PayrollDB");
        }


        public async Task<PayrollDocument> SaveFile(PayrollDocument payrollDocument)
        {
            try
            {
                using var db = new NpgsqlConnection(_payrollDb);
                db.Open();
                IDbTransaction transaction = db.BeginTransaction();

                int year = DateTime.Now.Year;
                string internalCode = await GeneratePayrollCode(year, db, transaction);

                payrollDocument.FileName = $"{internalCode}.txt";
                payrollDocument.InternalCode = internalCode;

                string sql = @"INSERT INTO public.payroll 
                       (id, file, created_at, internal_code) 
                       VALUES 
                       (@Id, @File, @CreatedAt, @InternalCode)";

                _ = await db.ExecuteAsync(sql, new
                {
                    payrollDocument.Id,
                    File = payrollDocument.Content,
                    payrollDocument.CreatedAt,
                    InternalCode = internalCode,
                }, transaction);

                transaction.Commit();

                return payrollDocument;
            }
            catch (Exception ex) {
                throw new RepositoryException("Error al guardar la nomina en bd", ex);
            }

        }

        private async Task<string> GeneratePayrollCode(int year, NpgsqlConnection db, IDbTransaction trans)
        {
            try
            {
                string sql = @"
                    INSERT INTO public.payroll_counters (year, last_value) 
                    VALUES (@year, 1)
                    ON CONFLICT (year) 
                    DO UPDATE SET last_value = payroll_counters.last_value + 1
                    RETURNING last_value;";

                int nextValue = await db.ExecuteScalarAsync<int>(sql, new { year }, trans);

                return $"NOM-{year}-{nextValue.ToString().PadLeft(4, '0')}";
            }
            catch (Exception ex) {
                throw new RepositoryException("Error al generar el nombre de la nomina en bd", ex);
            }
        }
    }
}
