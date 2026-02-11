using Domain.DTOs.CatalogoD;
using Domain.DTOs.UsuarioD;
using Domain.Entities.UsuarioE;
using Domain.Utilidades;
using Infrastructure;
using Infrastructure.Seguridad;
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
    public interface IUsuarioQueries
    {
        Task<InicioRespuestaDto> ObtenerUsuarioAsync(UsuarioInicioDto usuarioInicioDto);
    }
    public class UsuarioQueries : IUsuarioQueries, IDisposable
    {
        private readonly DBContext _contexto = null;
        private readonly ILogger<UsuarioQueries> _logger;
        private readonly IConfiguration _configuracion;
        private readonly IGenerarToken _generarToken;
        private readonly IPassword _password;

        public UsuarioQueries(ILogger<UsuarioQueries> logger, IConfiguration configuration, IGenerarToken generarToken, IPassword password)
        {
            _logger = logger;
            _configuracion = configuration;
            string? Conexion = _configuracion.GetConnectionString("Conexion");
            _contexto = new DBContext(Conexion);
            _generarToken = generarToken;
            _password = password;
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

        public async Task<InicioRespuestaDto> ObtenerUsuarioAsync(UsuarioInicioDto usuarioInicioDto)
        {
            _logger.LogDebug("Iniciando {Metodo}", nameof(ObtenerUsuarioAsync));
            try
            {
                var usuarioE = await _contexto.UsuarioEs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Correo == usuarioInicioDto.Correo.Trim() && u.Activo);

                if (usuarioE == null)
                {
                    return RespuestaError();
                }

                var verificarPassword = await _password.VerificarPasswordAsync(usuarioInicioDto.Password, usuarioE.Password);

                if (!verificarPassword)
                {
                    return RespuestaError();
                }

                var usuarioDto = UsuarioDto.CreateDTO(usuarioE);
                var token = _generarToken.GenerarTokenUsuario(usuarioDto);

                var respuesta = new InicioRespuestaDto()
                {
                    Respuesta = true,
                    Token = token,
                    Datos = usuarioDto
                };

                return respuesta;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ejecutando {Metodo}", nameof(ObtenerUsuarioAsync));
                throw;
            }
        }


        private static InicioRespuestaDto RespuestaError()
        {
            return new InicioRespuestaDto
            {
                Respuesta = false,
                Token = string.Empty,
                Datos = null,
            
            };
        }

    }
}
