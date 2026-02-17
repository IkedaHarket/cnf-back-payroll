namespace Backend.Payroll.API.Application.DTO.Response
{
    public class HealthCheckResponse
    {
        public bool Backend {  get; set; }
        public bool BancoEstado { get; set; }
    }
}
