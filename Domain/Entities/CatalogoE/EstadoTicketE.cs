using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Catalogos
{
    [Table("estados_ticket")]
    public class EstadoTicketE
    {
        [Key]
        [Column("id_estado")]
        public required int IdEstado { get; set; }

        [Column("nombre")]
        public required string Nombre { get; set; }

        [Column("es_final")]
        public required bool Final { get; set; }
    }
}
