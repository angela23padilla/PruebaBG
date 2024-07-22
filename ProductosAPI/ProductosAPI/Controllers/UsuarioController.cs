using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Model.Usuario;
using UsuariosAPI.Mapeador;

namespace ProductosAPI.Controllers
{
   
    public class UsuarioController : ControllerBase
    {
        private readonly MapeadorUsuario _mapUsuario;

        public UsuarioController(MapeadorUsuario mapUsuario)
        {
            _mapUsuario = mapUsuario;
        }


        [Route("api/Usuario/Validar")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> ValidarUsuario([FromBody] LoginRequest request)
        {
            var response = await _mapUsuario.Validar(request);
            return response;
        }

    }
}