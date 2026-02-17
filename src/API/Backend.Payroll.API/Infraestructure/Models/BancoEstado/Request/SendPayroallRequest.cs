namespace Backend.Payroll.API.Infraestructure.Models.BancoEstado.Request
{
    public class SendPayroallRequest
    {
        public int PaymentConcept { get; set; }
        public string PaymentDate { get; set; }
        public int TemplateCode { get; set; }
        public long TotalAmount { get; set; }
        public int RecordCount { get; set; }
        public string? PayrollName { get; set; }
        public long AgreementNumber { get; set; }
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
        public string AccessToken { get; set; }
    }
}
