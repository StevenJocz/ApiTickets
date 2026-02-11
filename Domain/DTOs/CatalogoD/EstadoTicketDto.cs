using Domain.Entities.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.CatalogoD
{
    public class EstadoTicketDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Final { get; set; }

        public static EstadoTicketDto CreateDTO(EstadoTicketE estadoE)
        {
            return new EstadoTicketDto
            {
                Id = estadoE.IdEstado,
                Nombre = estadoE.Nombre,
                Final = estadoE.Final
            };
        }

    }
}
