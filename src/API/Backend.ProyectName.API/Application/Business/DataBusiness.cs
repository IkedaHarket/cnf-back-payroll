using Backend.ProyectName.API.Application.Utils;
using Backend.ProyectName.API.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using RemoteModel = Backend.ProyectName.API.Infraestructure.Models;
using DTO = Backend.ProyectName.API.Application.DTO;
using System.Linq;
using System.Globalization;
using Backend.ProyectName.API.Persistence.Interfaces;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Text;
using Backend.ServiceName.API.Application.Interfaces;

namespace Backend.ProyectName.API.Application.Business
{
    public class DataBusiness : IDataBusiness
    {
        private readonly IServiceNameService _dataService;
        private readonly IDataBaseNameRepository _dataRepository;

        public DataBusiness(IServiceNameService dataService, IDataBaseNameRepository dataRepository)
        {
            _dataService = dataService;
            _dataRepository = dataRepository;
        }

        public async Task<DTO.Response.DataResponse> GetData(string code)
        {
            //se obtienen las polizas
            var data = await _dataService.GetData(code);

            DTO.Response.DataResponse dataReturn = new(){
				Code = data.Code,
				Data1 = data.Data1,
				Data2 = data.Data2,
				Data3 = data.Data3
			};

            return dataReturn;
        }
    }
}