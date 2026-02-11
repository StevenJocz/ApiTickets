using Domain.DTOs.CatalogoD;
using Domain.Entities.Catalogos;
using Domain.Entities.UsuarioE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.UsuarioD
{
    public class UsuarioDto
    {
        public Guid IdUsuario { get; set; }
        public  string Nombre { get; set; } = null!;
        public  string Correo { get; set; } = null!;
        public  string Rol { get; set; } = null!;
        public  bool Activo { get; set; } = true;

        public static UsuarioDto CreateDTO(UsuarioE usuarioE)
        {
            return new UsuarioDto
            {
                IdUsuario = usuarioE.IdUsuario,
                Nombre = usuarioE.Nombre,
                Correo = usuarioE.Correo,
                Rol = usuarioE.Rol,
                Activo  = usuarioE.Activo
            };
        }
    }
}
