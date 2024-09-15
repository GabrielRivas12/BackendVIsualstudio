using Dapper;
using BackendTest.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Services
{
    public class EstudianteServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public EstudianteServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Estudiante> GetEstudiante(int id)
        {
            string _queryCommand = "sp_ObtenerEstudiante";
            var parametro = new DynamicParameters();
            parametro.Add("@P_id",id,dbType: DbType.Int32);
            using (var con = new SqlConnection(_StringSql))
            {
                var _estudiante = await con.QueryFirstOrDefaultAsync<Estudiante>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _estudiante; 
            }

        }

        public async Task<string> PostEstudiante([FromBody] Estudiante _Oestudiante)
        {
            string _queryCommand = "sp_InsertarEstudiante";
            var parametro = new DynamicParameters();
            parametro.Add("@Nombre", _Oestudiante.Nombre, dbType: DbType.String);
            parametro.Add("@Apellidos", _Oestudiante.Apellidos, dbType: DbType.String);
            parametro.Add("@Direccion", _Oestudiante.Direccion, dbType: DbType.String);
            parametro.Add("@Ciudad", _Oestudiante.Ciudad, dbType: DbType.String);
            parametro.Add("@id_c", _Oestudiante.id_carrera, dbType: DbType.Int32); //modificacion aqui
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                    commandType: CommandType.StoredProcedure);
                return ("Estudiante registrado");
            }

        }

       

        public async Task<string> PutEstudiante([FromBody] Estudiante _Oestudiante)
        {
            string _queryCommand = "sp_ActualizarEstudiante";
            var parametro = new DynamicParameters();
            parametro.Add("@P_id", _Oestudiante.P_id, dbType: DbType.Int32);
            parametro.Add("@Nombre", _Oestudiante.Nombre, dbType: DbType.String);
            parametro.Add("@Apellidos", _Oestudiante.Apellidos, dbType: DbType.String);
            parametro.Add("@Direccion", _Oestudiante.Direccion, dbType: DbType.String);
            parametro.Add("@Ciudad", _Oestudiante.Ciudad, dbType: DbType.String);
            parametro.Add("@id_c", _Oestudiante.id_carrera, dbType: DbType.Int32); //modificacion aqui
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                    commandType: CommandType.StoredProcedure);
                return ("Estudiante Actualizado");
            }


        }

        public async Task<Estudiante> DeleteEstudiante(int id)
        {
            string _queryCommand = "sp_EliminarEstudiante";
            var parametro = new DynamicParameters();
            parametro.Add("@P_id", id, dbType: DbType.Int32);
            using (var con = new SqlConnection(_StringSql))
            {
                var _estudiante = await con.QueryFirstOrDefaultAsync<Estudiante>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _estudiante;
            }

        }

    }
}
