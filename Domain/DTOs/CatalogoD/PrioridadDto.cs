using Domain.Entities.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.CatalogoD
{
    public class PrioridadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Nivel { get; set; }

        public static PrioridadDto CreateDTO(PrioridadE prioridadE)
        {
            return new PrioridadDto
            {
                Id = prioridadE.IdPrioridad,
                Nombre = prioridadE.Nombre,
                Nivel = prioridadE.Nivel
            };
        }

        
    }
}
