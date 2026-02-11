using Domain.DTOs.CatalogoD;
using Domain.DTOs.TicketD;
using Domain.DTOs.UsuarioD;
using Domain.Entities.Catalogos;
using Domain.Entities.TicketE;
using Domain.Entities.UsuarioE;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Persistence.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries
{
    public interface ITicketQueries
    {
        Task<List<TicketDto>> ObtenerTicketsAsync();
        Task<ConsultarTicketDto> ObtenerTicketCodigoAsync(string codigo);
        Task<List<TicketDto>> ObtenerTicketIdUsurioAsync(Guid IdUsuario);
    }

    public class TicketQueries: ITicketQueries, IDisposable
    {
        private readonly DBContext _contexto = null;
        private readonly ILogger<TicketQueries> _logger;
        private readonly IConfiguration _configuracion;

        public TicketQueries(ILogger<TicketQueries> logger, IConfiguration configuration)
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


        public async Task<List<TicketDto>> ObtenerTicketsAsync()
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerTicketsAsync));
            try
            {
                var tickets = await _contexto.TicketEs
                    .AsNoTracking()
                    .Select(a => TicketDto.CrearDTO(a))
                    .ToListAsync();

                return tickets;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerTicketsAsync));
                throw;
            }
        }


        public async Task<ConsultarTicketDto> ObtenerTicketCodigoAsync(string codigo)
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerTicketsAsync));
            try
            {
                var ticket = await _contexto.TicketEs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Codigo == codigo.Trim());

                var area = await _contexto.AreaEs.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.IdArea == ticket.AreaId);

                var prioridad = await _contexto.PrioridadEs.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.IdPrioridad == ticket.PrioridadId);

                var estado = await _contexto.EstadoTicketEs.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.IdEstado == ticket.EstadoId);

                var TicketsDto = new ConsultarTicketDto()
                {
                    IdTicket = ticket.IdTicket,
                    Codigo = ticket.Codigo,
                    Titulo = ticket.Titulo,
                    Descripcion = ticket.Descripcion,
                    Area = area.Nombre,
                    Prioridad = prioridad.Nombre,
                    Estado = estado.Nombre,
                    FechaCreacion = ticket.FechaCreacion,
                    FechaActualizacion =  ticket.FechaActualizacion
                };


                return TicketsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerTicketsAsync));
                throw;
            }
        }


        public async Task<List<TicketDto>> ObtenerTicketIdUsurioAsync(Guid IdUsuario)
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerTicketsAsync));
            try
            {
                var tickets = await _contexto.TicketEs
                .AsNoTracking()
                .Where(t => t.UsuarioId == IdUsuario)
                .Select(t => TicketDto.CrearDTO(t))
                .ToListAsync();

                return tickets;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerTicketsAsync));
                throw;
            }
        }
    }
}
