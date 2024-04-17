using Backend.ProyectName.API.Persistence.Interfaces;
using Backend.ProyectName.API.Persistence.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Backend.ProyectName.API.Persistence.Repositories
{
    public class DataBaseNameRepository : IDataBaseNameRepository
    {
        private readonly string _dataBaseNameDb;

        public DataBaseNameRepository(IConfiguration configuration)
        {
            _dataBaseNameDb = configuration.GetConnectionString("PortalWebDB");
        }

        public async Task<Data> GetData(string code)
        {
            using var db = new NpgsqlConnection(_dataBaseNameDb);

            string query = $@"SELECT * FROM Table WHERE and code = '{code}'";

            return await db.QueryFirstOrDefaultAsync<Data>(query);
        }

        public async Task<List<Data>> GetDatas()
        {
            using var db = new NpgsqlConnection(_dataBaseNameDb);

            string query = $@"SELECT * FROM Tabla";

            var dataReturn = await db.QueryAsync<Data>(query);

            return dataReturn.ToList();
        }

        public async Task<bool> Insert(string code)
        {
            using var db = new NpgsqlConnection(_dataBaseNameDb);
            db.Open();
            IDbTransaction transaction = db.BeginTransaction();

            string sql0 = @"INSERT INTO tabla
                                (code) VALUES
                                (@code)";
            await db.ExecuteAsync(sql0,
                new
                {
                    Code = code
                }, transaction);

            transaction.Commit();
            return true;
        }

        public async Task<bool> Update(Data data, string code)
        {
            using var db = new NpgsqlConnection(_dataBaseNameDb);
            string updateBankInformation = $@"UPDATE tabla
                                            SET 
                                              data1 = @data1,
                                              data2 = @data2,
                                              data3 = @data3
                                            WHERE code = @code;";

            DynamicParameters parameters= new DynamicParameters();
            parameters.Add("@data1", data.Data1);
            parameters.Add("@data2", data.Data2);
            parameters.Add("@data3", data.Data3);
            parameters.Add("@code", code);

            var response = await db.ExecuteAsync(updateBankInformation, parameters);

            return response == 1;
        }
    }
}