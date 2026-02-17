using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Backend.Payroll.API.Domain.Models
{
    public class Settlement
    {
        public int Id { get; set; }
        public string? PayrollId { get; set; }
        public string? PaymentDateFrom { get; set; }
        public string? PaymentDateTo { get; set; }
        public long? AgreementNumber { get; set; }
        public string? RecipientTaxId { get; set; } 
        public string? RecipientName { get; set; } 
        public string? BankName { get; set; } 
        public string? AccountNumberOrDocument { get; set; } 
        public string? PaymentMethodDescription { get; set; }
        public string? PaymentDate { get; set; } 
        public int? Amount { get; set; } 
        public string? Status { get; set; }
        public string? RejectionReason { get; set; }
    }
}
