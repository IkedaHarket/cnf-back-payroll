using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using DTO = Backend.ProyectName.API.Application.DTO;
using System;

namespace Backend.ServiceName.API.Application.Interfaces
{
    public interface IDataBusiness
    {
        Task<DTO.Response.DataResponse> GetData(string code);
    }
}