using Domain.DTOs.CatalogoD;
using Domain.Entities.Catalogos;
using Domain.Entities.TicketE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.TicketD
{
    public class TicketDto
    {
        public  Guid? IdTicket { get; set; }
        public  string? Codigo { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public required Guid UsuarioId { get; set; }
        public required int AreaId { get; set; }
        public required int PrioridadId { get; set; }
        public required int EstadoId { get; set; }
        public  DateTime FechaCreacion { get; set; }
        public  DateTime FechaActualizacion { get; set; }


        public static TicketDto CrearDTO(TicketE ticketE)
        {
            return new TicketDto
            {
                IdTicket = ticketE.IdTicket,
                Codigo = ticketE.Codigo,
                Titulo = ticketE.Titulo,
                Descripcion = ticketE.Descripcion,
                UsuarioId = ticketE.UsuarioId,
                AreaId = ticketE.AreaId,
                PrioridadId = ticketE.PrioridadId,
                EstadoId = ticketE.EstadoId,
                FechaCreacion = ticketE.FechaCreacion,
                FechaActualizacion = ticketE.FechaActualizacion,
            };
        }

        public static TicketE CrearE(TicketDto ticketDto)
        {
            return new TicketE
            {
                Codigo = ticketDto.Codigo,
                Titulo = ticketDto.Titulo,
                Descripcion = ticketDto.Descripcion,
                UsuarioId = ticketDto.UsuarioId,
                AreaId = ticketDto.AreaId,
                PrioridadId = ticketDto.PrioridadId,
                EstadoId = ticketDto.EstadoId,
                FechaCreacion = ticketDto.FechaCreacion,
                FechaActualizacion = ticketDto.FechaActualizacion,
            };
        }

    }

    public class CrearticketDto
    {
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public required Guid UsuarioId { get; set; } = Guid.NewGuid();
        public required int AreaId { get; set; }
        public required int PrioridadId { get; set; }
        public required int EstadoId { get; set; }
    }

    public class ActualizarEstadoTicketDto
    {
        public Guid Id { get; set; }
        public int EstadoId { get; set; }
    }

    public class ConsultarTicketDto
    {
        public Guid? IdTicket { get; set; }
        public required string Titulo { get; set; }
        public required string Codigo { get; set; }
        public required string Descripcion { get; set; }
        public required string Area { get; set; }
        public required string Prioridad { get; set; }
        public required string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
