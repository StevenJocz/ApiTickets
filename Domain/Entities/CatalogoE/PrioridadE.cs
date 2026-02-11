using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Catalogos
{
    [Table("prioridades")]
    public class PrioridadE
    {
        [Key]
        [Column("id_prioridad")]
        public required int IdPrioridad { get; set; }

        [Column("nombre")]
        public required string Nombre { get; set; }

        [Column("nivel")]
        public required int Nivel { get; set; }
    }
}
