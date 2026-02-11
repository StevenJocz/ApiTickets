using Domain.DTOs.CatalogoD;
using Domain.DTOs.TicketD;
using Domain.Entities.TicketE;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Persistence.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands
{

    public interface ITicketCommands
    {
        Task<RespuestaDto> CrearTicketAsync(CrearticketDto crearticketDto);
        Task<RespuestaDto> ActualizarEstadoTicketAsync(ActualizarEstadoTicketDto dto);
    }
    public class TicketCommands: ITicketCommands, IDisposable
    {
        private readonly DBContext _contexto = null;
        private readonly ILogger<TicketCommands> _logger;
        private readonly IConfiguration _configuracion;

        public TicketCommands(ILogger<TicketCommands> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuracion = configuration;
            string? Conexion = _configuracion.GetConnectionString("Conexion");
            _contexto = new DBContext(Conexion);
        }

        #region implementacion Disponse
        bool _desechado = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool liberandoRecursos)
        {
            if (!_desechado)
            {
                if (liberandoRecursos)
                {
                    _contexto.Dispose();
                }
                _desechado = true;
            }
        }
        #endregion

        public async Task<RespuestaDto> CrearTicketAsync(CrearticketDto crearticketDto)
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(CrearTicketAsync));
            try
            {
                var ultimoTicket = await _contexto.Database.SqlQuery<int>($"SELECT nextval('ticket_numero_seq') AS \"Value\"").SingleAsync();

                string codigo = ultimoTicket.ToString("D3");

                var ticket = new TicketDto
                {
                    Codigo = codigo,  
                    Titulo = crearticketDto.Titulo,
                    Descripcion = crearticketDto.Descripcion,
                    UsuarioId = crearticketDto.UsuarioId,
                    AreaId = crearticketDto.AreaId,
                    PrioridadId = crearticketDto.PrioridadId,
                    EstadoId = crearticketDto.EstadoId,
                    FechaCreacion = DateTime.UtcNow,
                    FechaActualizacion = DateTime.UtcNow,
                };

                var ticketE = TicketDto.CrearE(ticket);
                await _contexto.TicketEs.AddAsync(ticketE);
                await _contexto.SaveChangesAsync();

                return new RespuestaDto
                {
                    respuesta = true,
                    mensaje = "Ticket creado correctamente.",
                    ticket = codigo,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(CrearTicketAsync));
                throw;
            }


        }

        public async Task<RespuestaDto> ActualizarEstadoTicketAsync(ActualizarEstadoTicketDto dto)
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ActualizarEstadoTicketAsync));

            try
            {
                var filasAfectadas = await _contexto.TicketEs
                    .Where(t => t.IdTicket == dto.Id)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(t => t.EstadoId, dto.EstadoId)
                        .SetProperty(t => t.FechaActualizacion, DateTime.UtcNow)
                    );

                if (filasAfectadas == 0)
                {
                    return new RespuestaDto
                    {
                        respuesta = false,
                        mensaje = "No se encontró el ticket."
                    };
                }

                return new RespuestaDto
                {
                    respuesta = true,
                    mensaje = "Estado del ticket actualizado correctamente."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ActualizarEstadoTicketAsync));
                throw;
            }
        }

    }
}
