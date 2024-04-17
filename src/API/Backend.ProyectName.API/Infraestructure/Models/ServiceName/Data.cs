using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Infraestructure.Models.ServiceName
{
    public class Data
    {
        [JsonProperty("Code")]
        public string Code { get; set; }


        [JsonProperty("Data1")]
        public string Data1 { get; set; }


        [JsonProperty("Data2")]
        public string Data2 { get; set; }


        [JsonProperty("Data3")]
        public string Data3 { get; set; }
    }
}