using Domain.Entities.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.CatalogoD
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public static AreaDto CreateDTO(AreaE areaE)
        {
            return new AreaDto
            {
                Id = areaE.IdArea,
                Nombre = areaE.Nombre,
                Activo  = areaE.Activo
            };
        }

    }
}
