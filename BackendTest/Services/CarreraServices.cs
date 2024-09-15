using Dapper;
using BackendTest.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace BackendTest.Services
{
    public class CarreraServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public CarreraServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Carrera> GetCarrera(int id)
        {
            string _queryCommand = "sp_ObtenerCarrera";
            var parametro = new DynamicParameters();
            parametro.Add("@id_c", id, DbType.Int32);
            using (var con = new SqlConnection(_StringSql))
            {
                var _carrera = await con.QueryFirstOrDefaultAsync<Carrera>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _carrera;
            }


        }

        public async Task<string> PostCarrera([FromBody] Carrera _Ocarrera)
        {
            string _queryCommand = "sp_InsertarCarrera";
            var parametro = new DynamicParameters();
            parametro.Add("@nombreC", _Ocarrera.NombreCarrera, dbType: DbType.String);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                    commandType: CommandType.StoredProcedure);
                return ("Estudiante registrado");
            }

        }

        public async Task<string> PutCarrera([FromBody] Carrera _Ocarrera)
        {
            string _queryCommand = "sp_ActualizarCarrera";
            var parametro = new DynamicParameters();
            parametro.Add("@id_c", _Ocarrera.Id, dbType: DbType.Int32);
            parametro.Add("@nombreC", _Ocarrera.NombreCarrera, dbType: DbType.String);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                    commandType: CommandType.StoredProcedure);
                return ("Carrera Actualizado");
            }


        }

        public async Task<Carrera> DeleteCarrera(int id)
        {
            string _queryCommand = "sp_EliminarCarrera";
            var parametro = new DynamicParameters();
            parametro.Add("@id_c", id, dbType: DbType.Int32);
            using (var con = new SqlConnection(_StringSql))
            {
                var _carrera= await con.QueryFirstOrDefaultAsync<Carrera>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _carrera;
            }

        }

    }
}
