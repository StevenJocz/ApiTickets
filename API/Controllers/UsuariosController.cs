using Domain.DTOs.UsuarioD;
using Microsoft.AspNetCore.Mvc;
using Persistence.Queries;

namespace Tickets.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioQueries _usuarioQueries;

        public UsuariosController(IUsuarioQueries usuarioQueries)
        {
            _usuarioQueries = usuarioQueries;
        }

        [HttpPost("login")]
        public async Task<IActionResult> ListarUsuario([FromBody] UsuarioInicioDto usuarioInicioDto)
        {
            var usuario = await _usuarioQueries.ObtenerUsuarioAsync(usuarioInicioDto);
            return Ok(usuario);
        }
        
    }
}
