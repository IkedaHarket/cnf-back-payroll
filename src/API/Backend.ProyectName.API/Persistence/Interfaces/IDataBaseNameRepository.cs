using Backend.ProyectName.API.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Persistence.Interfaces
{
    public interface IDataBaseNameRepository
    {
        Task<Data> GetData(string code);
		
		Task<List<Data>> GetDatas();
		
		Task<bool> Insert(string code);
		
		Task<bool> Update(Data data, string code);
    }
}