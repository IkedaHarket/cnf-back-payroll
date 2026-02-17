using iTextSharp.text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Payroll.API.Infraestructure.Models.BancoEstado.Responses
{
    public class GetPayrollResponse
    {
        [JsonProperty("meta")]
        public GetPayrollMeta Meta { get; set; }

        [JsonProperty("links")]
        public GetPayrollLinks Links { get; set; }

        [JsonProperty("data")]
        public List<GetPayrollData> Data { get; set; }
    }

    public class GetPayrollData
    {
        [JsonProperty("IdNomina")]
        public string IdNomina { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("numeroConvenio")]
        public string NumeroConvenio { get; set; }

        [JsonProperty("fechaPago")]
        public string FechaPago { get; set; }

        [JsonProperty("montoNomina")]
        public string MontoNomina { get; set; }

        [JsonProperty("codigoEstado")]
        public string CodigoEstado { get; set; }

        [JsonProperty("glosaEstado")]
        public string GlosaEstado { get; set; }

        [JsonProperty("totalRegistros")]
        public string TotalRegistros { get; set; }
    }

    public class GetPayrollLinks
    {
    }

    public class GetPayrollMeta
    {
        [JsonProperty("firstAvailableDateTime")]
        public DateTime FirstAvailableDateTime { get; set; }

        [JsonProperty("lastAvailableDateTime")]
        public DateTime LastAvailableDateTime { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }
}
