using Backend.ProyectName.API.Infraestructure.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.ProyectName.API.Infraestructure.Models.ServiceName;
using System.util;
using Backend.ProyectName.API.Application.Utils;
using System;

namespace Backend.ProyectName.API.Infraestructure.Services
{
    public class ServiceNameService : IServiceNameService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string CLIENT = "ServiceName";

        public ServiceNameService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Data> GetData(string code)
        {
            var client = _httpClientFactory.CreateClient(CLIENT);

            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress.AbsolutePath}api/Data/{code}");

            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Data dataReturn = JsonConvert.DeserializeObject<Data>(data);
                return dataReturn;
            }
            else
            {
                throw new System.Exception(data);
            }
        }

        public async Task<Data> PutData(Data data, string code)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            var ChangeContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient(CLIENT);
            HttpResponseMessage response = await client.PutAsync($"{client.BaseAddress.AbsolutePath}api/Data/{code}", ChangeContent);

            var dataResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Data result = JsonConvert.DeserializeObject<Data>(dataResponse);
                return result;
            }
            else
            {
                throw new System.Exception(dataResponse);                
            }
        }
    }
}