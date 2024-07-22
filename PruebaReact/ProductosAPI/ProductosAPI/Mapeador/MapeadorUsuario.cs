using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using ProductosAPI.Model.Usuario;

namespace UsuariosAPI.Mapeador
{
    public class MapeadorUsuario
    {
        private readonly IConfiguration _configuration;

        public MapeadorUsuario(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

       

        public  async Task<ActionResult<LoginResponse>> Validar(LoginRequest request)
        {
            var connectionString = _configuration.GetConnectionString("Conexion");
            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand("sp_Usuario", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Agrega los parámetros del procedimiento almacenado
            command.Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int) { Value = 1 });
            command.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 50) { Value = request.Usuario });
            command.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.VarChar, 100) { Value = request.Contraseña });
            
            
            connection.Open();
            var response = new LoginResponse();

            using var reader = await command.ExecuteReaderAsync();
           
            while (reader.Read())
            {
                var success = reader["Success"];
                var message = reader["Message"];

                response = new LoginResponse()
                {
                    Success = Convert.ToBoolean(success),
                    Message = Convert.ToString(message)
                };

            }
            return response;
        }

        
    }
}
