namespace Backend.Payroll.API.Infraestructure.Models.BancoEstado.Request
{
    public class GetTokenRequest
    {
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; } = "openid";
    }
}
