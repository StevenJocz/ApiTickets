using Domain.DTOs.CatalogoD;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries
{
    public interface ICatalogoQueries
    {
        Task<List<AreaDto>> ObtenerAreasAsync();
        Task<List<PrioridadDto>> ObtenerPrioridadesAsync();
        Task<List<EstadoTicketDto>> ObtenerEstadosAsync();
    }
    public class CatalogoQueries : ICatalogoQueries, IDisposable
    {
        private readonly DBContext _contexto = null;
        private readonly ILogger<CatalogoQueries> _logger;
        private readonly IConfiguration _configuracion;

        public CatalogoQueries(ILogger<CatalogoQueries> logger, IConfiguration configuration)
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


        public async Task<List<AreaDto>> ObtenerAreasAsync()
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerAreasAsync));
            try
            {
                var areas = await _contexto.AreaEs
                    .AsNoTracking()
                    .Select(a => AreaDto.CreateDTO(a))
                    .ToListAsync();

                return areas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerAreasAsync));
                throw;
            }
        }

        public async Task<List<PrioridadDto>> ObtenerPrioridadesAsync()
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerPrioridadesAsync));
            try
            {
                var prioridades = await _contexto.PrioridadEs
                    .AsNoTracking()
                    .Select(a => PrioridadDto.CreateDTO(a))
                    .ToListAsync();

                return prioridades;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerPrioridadesAsync));
                throw;
            }
        }
        public async Task<List<EstadoTicketDto>> ObtenerEstadosAsync()
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerEstadosAsync));
            try
            {
                var estados = await _contexto.EstadoTicketEs
                    .AsNoTracking()
                    .Select(a => EstadoTicketDto.CreateDTO(a))
                    .ToListAsync();

                return estados;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerEstadosAsync));
                throw;
            }
        }
    }
}
