using System;

namespace Backend.Payroll.API.Domain.Models
{
    public class PayrollDocument
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PaymentDate { get; set; }
        public int TemplateCode { get; set; }
        public long TotalAmount { get; set; }
        public int RecordCount { get; set; }
        public string? PayrollName { get; set; }
        public long AgreementNumber { get; set; }
        public string FileName { get; set; }
    }
}
