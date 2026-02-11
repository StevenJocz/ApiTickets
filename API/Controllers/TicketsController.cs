using Domain.DTOs.TicketD;
using Domain.DTOs.UsuarioD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Commands;
using Persistence.Queries;

namespace Tickets.Controllers
{
    //[Authorize]
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ITicketQueries _ticketQueries;
        private readonly ITicketCommands _ticketCommands;

        public TicketsController(ITicketQueries ticketQueries, ITicketCommands ticketCommands)
        {
            _ticketQueries = ticketQueries;
            _ticketCommands = ticketCommands;
        }


        [HttpPost()]
        public async Task<IActionResult> CrearTicket([FromBody] CrearticketDto crearticketDto)
        {
            var usuario = await _ticketCommands.CrearTicketAsync(crearticketDto);
            return Ok(usuario);
        }

        [HttpPatch("estado")]
        public async Task<ActionResult<RespuestaDto>> ActualizarEstado([FromBody] ActualizarEstadoTicketDto dto)
        {
            var respuesta = await _ticketCommands.ActualizarEstadoTicketAsync(dto);

            if (!respuesta.respuesta)
                return NotFound(respuesta);

            return Ok(respuesta);
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTickets()
        {
            var tickets = await _ticketQueries.ObtenerTicketsAsync();
            return Ok(tickets);
        }


        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObtenerPorCodigo(string codigo)
        {
            var ticket = await _ticketQueries.ObtenerTicketCodigoAsync(codigo);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ObtenerPorUsuario(Guid usuarioId)
        {
            var tickets = await _ticketQueries.ObtenerTicketIdUsurioAsync(usuarioId);
            return Ok(tickets);
        }
    }
}
