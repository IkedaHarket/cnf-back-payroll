using Newtonsoft.Json;
using System;

namespace Backend.Payroll.API.Infraestructure.Models.BancoEstado.Responses
{
    public class SendPayrollResponse
    {
        [JsonProperty("meta")]
        public SendPayrollMeta Meta { get; set; }

        [JsonProperty("links")]
        public SendPayrollLinks Links { get; set; }

        [JsonProperty("data")]
        public SendPayrollData Data { get; set; }
    }
    public class SendPayrollData
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty("resultado")]
        public string Resultado { get; set; }

        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        [JsonProperty("codigoOperacion")]
        public string CodigoOperacion { get; set; }
    }

    public class SendPayrollLinks
    {
    }

    public class SendPayrollMeta
    {
        [JsonProperty("firstAvailableDateTime")]
        public DateTime FirstAvailableDateTime { get; set; }

        [JsonProperty("lastAvailableDateTime")]
        public DateTime LastAvailableDateTime { get; set; }
    }

    public class SendPayrollNomina
    {
        [JsonProperty("mensajeEstado")]
        public string MensajeEstado { get; set; }

        [JsonProperty("IdNomina")]
        public string IdNomina { get; set; }
    }

    public class Payload
    {
        [JsonProperty("nomina")]
        public SendPayrollNomina Nomina { get; set; }
    }
}
