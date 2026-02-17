using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Payroll.API.Infraestructure.Models.BancoEstado.Responses
{
    public class GetSettlementResponse
    {
        [JsonProperty("meta")]
        public GetSettlementMeta Meta { get; set; }

        [JsonProperty("links")]
        public GetSettlementLinks Links { get; set; }

        [JsonProperty("data")]
        public List<GetSettlementData> Data { get; set; }
    }

    public class GetSettlementData
    {
        [JsonProperty("IdNomina")]
        public int IdNomina { get; set; }

        [JsonProperty("idRegistro")]
        public int IdRegistro { get; set; }

        [JsonProperty("rutDestinatario")]
        public string RutDestinatario { get; set; }

        [JsonProperty("nombreDestinatario")]
        public string NombreDestinatario { get; set; }

        [JsonProperty("GlosaBanco")]
        public string GlosaBanco { get; set; }

        [JsonProperty("numCuentaODocumento")]
        public string NumCuentaODocumento { get; set; }

        [JsonProperty("GlosaFormaDePago")]
        public string GlosaFormaDePago { get; set; }

        [JsonProperty("fechaPago")]
        public string FechaPago { get; set; }

        [JsonProperty("monto")]
        public int Monto { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("motivoRechazo")]
        public string MotivoRechazo { get; set; }
    }

    public class GetSettlementLinks
    {
    }

    public class GetSettlementMeta
    {
        [JsonProperty("firstAvailableDateTime")]
        public DateTime FirstAvailableDateTime { get; set; }

        [JsonProperty("lastAvailableDateTime")]
        public DateTime LastAvailableDateTime { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }
}
