namespace Backend.Payroll.API.Application.DTO.Request
{
    public class GetSettlementsRequest
    {
        public string? PayrollId { get; set; }
        public string? PaymentDateFrom { get; set; }
        public string? PaymentDateTo { get; set; }
        public long AgreementNumber { get; set; }
    }
}
