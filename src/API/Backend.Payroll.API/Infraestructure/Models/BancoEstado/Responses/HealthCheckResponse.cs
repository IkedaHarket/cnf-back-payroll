using Newtonsoft.Json;
using System;

namespace Backend.Payroll.API.Infraestructure.Models.BancoEstado.Responses
{
    public class HealthCheckResponse
    {
        [JsonProperty("meta")]
        public HealthCheckMeta Meta { get; set; }

        [JsonProperty("links")]
        public HealthCheckLinks Links { get; set; }

        [JsonProperty("data")]
        public HealthCheckData Data { get; set; }
    }
    public class HealthCheckData
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

    public class HealthCheckLinks
    {
    }

    public class HealthCheckMeta
    {
        [JsonProperty("firstAvailableDateTime")]
        public DateTime FirstAvailableDateTime { get; set; }

        [JsonProperty("lastAvailableDateTime")]
        public DateTime LastAvailableDateTime { get; set; }
    }

    public class HealthCheckPayload
    {
    }
}
