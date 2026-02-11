using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TicketE
{
    [Table("tickets")]
    public class TicketE
    {
        [Key]
        [Column("id_ticket")]
        public  Guid? IdTicket { get; set; } = Guid.NewGuid();


        [Column("codigo_seguimiento")]
        public required string Codigo { get; set; }


        [Column("titulo")]
        public required string Titulo { get; set; }


        [Column("descripcion")]
        public required string Descripcion { get; set; }


        [Column("id_usuario")]
        public required Guid UsuarioId { get; set; }


        [Column("id_area")]
        public required int AreaId { get; set; }


        [Column("id_prioridad")]
        public required int PrioridadId { get; set; }


        [Column("id_estado")]
        public required int EstadoId { get; set; }


        [Column("fecha_creacion")]
        public required DateTime FechaCreacion { get; set; }


        [Column("fecha_actualizacion")]
        public required DateTime FechaActualizacion { get; set; }

    }
}
