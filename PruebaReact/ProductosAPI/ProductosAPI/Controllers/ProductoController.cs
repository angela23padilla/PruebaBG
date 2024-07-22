using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosAPI.Data;
using ProductosAPI.Mapeador;
using ProductosAPI.Model.Producto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductosAPI.Controllers
{

    public class ProductoController : ControllerBase
    {
        private readonly MapeadorProducto _mapProducto;


        public ProductoController(MapeadorProducto mapProducto)
        {
            _mapProducto = mapProducto;
        }

        // GET: api/<ProductoController>
        [Route("api/Producto/ConsultarProducto")]
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> ConsultarProducto([FromQuery] int productoId, string nombreProducto,string categoria)
        {
            var response = await _mapProducto.ConsultarProducto(productoId, nombreProducto,categoria);
            return response;
        }

        [Route("api/Producto/GrabarProducto")]
        [HttpPost]
        public async Task<ActionResult<ProductoResponse>> GrabarProducto([FromBody] GrabarProductoModel producto)
        {
            var response = await _mapProducto.GrabarProducto(producto);
            return response;
        }


        
        [Route("api/Producto/EliminarProdDeseado")]
        [HttpDelete]
        public async Task<ActionResult<ProductoResponse>> EliminarProdDeseado([FromBody] EliminarProductoModel producto)
        {
            var response = await _mapProducto.EliminarProdDeseado(producto);
            return response;
        }


        // GET: api/<ProductoController>
        [Route("api/Producto/ConsultarProductoCarrito")]
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> ConsultarProductoCarrito([FromQuery] int usuarioID)
        {
            var response = await _mapProducto.ConsultarProductoCarrito(usuarioID);
            return response;
        }
    }
}
