using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProductosAPI.Model.Producto;
using System.Data;

namespace ProductosAPI.Mapeador
{
    public class MapeadorProducto
    {
        private readonly IConfiguration _configuration;

        public MapeadorProducto(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public async Task<ActionResult<List<Productos>>> ConsultarProducto(int productoId, string producto,string Categoria)
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("Conexion");
                using var connection = new SqlConnection(connectionString);

                using var command = new SqlCommand("sp_Producto", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega los parámetros del procedimiento almacenado
                command.Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int) { Value = 1 });
                if (productoId > 0)
                {
                    command.Parameters.Add(new SqlParameter("@id_producto", SqlDbType.Int) { Value = productoId });
                }

                command.Parameters.Add(new SqlParameter("@Producto", SqlDbType.VarChar,100) { Value = producto });
                command.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar,100) { Value = Categoria });
                
                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                var productos = new List<Productos>();
                while (reader.Read())
                {
                    var ProductoID = reader["id_producto"];
                    var nombre = reader["nombre"];
                    var descripcion = reader["descripcion"];
                    var precio = reader["precio"];
                    var stock = reader["stock"];
                    var categoria = reader["categoria"];
                    var fecha = reader["fecha_ingreso"];
                    var imagen = reader["imagen"];
                    var estado = reader["EstadoID"];
                    var validacion = reader["Validacion"];
                   


                    var objProducto = new Productos()
                    {
                        ProductoID = Convert.ToInt32(ProductoID),
                        Nombre = Convert.ToString(nombre),
                        Descripcion = Convert.ToString(descripcion),
                        Precio = Convert.ToDecimal(precio),
                        Stock  = Convert.ToInt32(stock),
                        Categoria = Convert.ToString(categoria),
                        FechaIngreso=Convert.ToDateTime(fecha),
                        Imagen = Convert.ToString(imagen),
                        EstadoID = Convert.ToInt32(estado),
                        Validacion = Convert.ToBoolean(validacion)
                        

                    };

                    productos.Add(objProducto);
                }
                return productos;

            }
            catch (Exception)
            {
                
                return null;
            }



        }

        public async Task<ActionResult<List<Productos>>> ConsultarProductoCarrito(int usuarioID)
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("Conexion");
                using var connection = new SqlConnection(connectionString);

                using var command = new SqlCommand("sp_ProductoDeseado", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega los parámetros del procedimiento almacenado
                command.Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int) { Value = 3 });
              
                    command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int) { Value = usuarioID });
                


                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                var productos = new List<Productos>();
                while (reader.Read())
                {
                    var ProductoID = reader["id_producto"];
                    var nombre = reader["nombre"];
                    var descripcion = reader["descripcion"];
                    var precio = reader["precio"];
                    var stock = reader["stock"];
                    var categoria = reader["categoria"];
                    var fecha = reader["fecha_ingreso"];
                    var imagen = reader["imagen"];
                   


                    var objProducto = new Productos()
                    {
                        ProductoID = Convert.ToInt32(ProductoID),
                        Nombre = Convert.ToString(nombre),
                        Descripcion = Convert.ToString(descripcion),
                        Precio = Convert.ToDecimal(precio),
                        Stock = Convert.ToInt32(stock),
                        Categoria = Convert.ToString(categoria),
                        FechaIngreso = Convert.ToDateTime(fecha),
                        Imagen = Convert.ToString(imagen)

                    };

                    productos.Add(objProducto);
                }
                return productos;

            }
            catch (Exception)
            {

                return null;
            }



        }

        public  async Task<ActionResult<ProductoResponse>> GrabarProducto(GrabarProductoModel producto)
        {
            var connectionString = _configuration.GetConnectionString("Conexion");
            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand("sp_ProductoDeseado", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Agrega los parámetros del procedimiento almacenado
            command.Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int) { Value = 1 });
            command.Parameters.Add(new SqlParameter("@id_producto", SqlDbType.Int) { Value = producto.ProductoID });
            command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int) { Value = producto.UsuarioID });
            
            
            connection.Open();
            var response = new ProductoResponse();

            using var reader = await command.ExecuteReaderAsync();
           
            while (reader.Read())
            {
                var success = reader["Success"];
                var message = reader["Message"];

                response = new ProductoResponse()
                {
                    Success = Convert.ToBoolean(success),
                    Message = Convert.ToString(message)
                };

            }
            return response;
        }

        public async Task<ActionResult<ProductoResponse>> ModificarProducto(ModificarProductoModel producto)
        {
            var connectionString = _configuration.GetConnectionString("Conexion");
            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand("sp_Producto", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Agrega los parámetros del procedimiento almacenado
            command.Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int) { Value = 3 });
            command.Parameters.Add(new SqlParameter("@Producto", SqlDbType.VarChar, 100) { Value = producto.Producto });
            command.Parameters.Add(new SqlParameter("@id_producto", SqlDbType.VarChar, 100) { Value = producto.ProductoID });

            connection.Open();
            var response = new ProductoResponse();

            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                var success = reader["Success"];
                var message = reader["Message"];

                response = new ProductoResponse()
                {
                    Success = Convert.ToBoolean(success),
                    Message = Convert.ToString(message)
                };

            }
            return response;
        }

        public async Task<ActionResult<ProductoResponse>> EliminarProdDeseado(EliminarProductoModel producto)
        {
            var connectionString = _configuration.GetConnectionString("Conexion");
            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand("sp_ProductoDeseado", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Agrega los parámetros del procedimiento almacenado
            command.Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int) { Value = 2 });
            command.Parameters.Add(new SqlParameter("@id_producto", SqlDbType.VarChar, 100) { Value = producto.ProductoID });
            command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.VarChar, 100) { Value = producto.UsuarioID });

            connection.Open();
            var response = new ProductoResponse();

            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                var success = reader["Success"];
                var message = reader["Message"];

                response = new ProductoResponse()
                {
                    Success = Convert.ToBoolean(success),
                    Message = Convert.ToString(message)
                };

            }
            return response;
        }
    }
}
