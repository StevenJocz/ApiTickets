using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.UsuarioD
{
    public class InicioRespuestaDto
    {
        public bool Respuesta { get; set; }
        public string Token { get; set; } = null!;
        public UsuarioDto? Datos { get; set; }
    }
}
