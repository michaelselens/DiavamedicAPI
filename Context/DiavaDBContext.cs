using Diavamedic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diavamedic.Context
{
    public class DiavaDBContext : DbContext
    {
        public DiavaDBContext(DbContextOptions<DiavaDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Remitos> Remito { get; set; }
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Conductores> Conductor { get; set; }
        public DbSet<Vehiculos> Vehiculo { get; set; }


    }
}
