using Backend.ProyectName.API.Infraestructure.Models.ServiceName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Infraestructure.Interfaces
{
    public interface IServiceNameService
    {
        Task<Data> GetData(string code);

        Task<Data> PutData(Data data, string code);
    }
}