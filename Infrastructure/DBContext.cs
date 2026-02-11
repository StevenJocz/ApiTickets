using Domain.Entities.Catalogos;
using Domain.Entities.TicketE;
using Domain.Entities.UsuarioE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DBContext : DbContext
    {
        private readonly string _connection;

        public DBContext(string connection)
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Usuario
        public virtual DbSet<UsuarioE> UsuarioEs { get; set; }

        // Catalogo
        public virtual DbSet<AreaE> AreaEs { get; set; }
        public virtual DbSet<PrioridadE> PrioridadEs { get; set; }
        public virtual DbSet<EstadoTicketE> EstadoTicketEs { get; set; }

        // Ticket
        public virtual DbSet<TicketE> TicketEs { get; set; }

    }
}
