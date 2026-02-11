using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UsuarioE
{
    [Table("usuarios")]
    public class UsuarioE
    {
        [Key]
        [Column("id_usuario")]
        public required Guid IdUsuario { get; set; }

        [Column("nombre")]
        public required string Nombre { get; set; } = null!;

        [Column("correo")]
        public required string Correo { get; set; } = null!;

        [Column("password_hash")]
        public required string Password{ get; set; } = null!;

        [Column("rol")]
        public required string Rol { get; set; } = null!;

        [Column("activo")]
        public required bool Activo { get; set; } = true;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }
    }
}
