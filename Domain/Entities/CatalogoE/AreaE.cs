using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Catalogos
{
    [Table("areas")]
    public class AreaE
    {
        [Key]
        [Column("id_area")]
        public required int IdArea { get; set; }

        [Column("nombre")]
        public required string Nombre { get; set; }

        [Column("activo")]
        public required bool Activo { get; set; }
    }
}
