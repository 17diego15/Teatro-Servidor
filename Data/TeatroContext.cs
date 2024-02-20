using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TeatroContext : DbContext
    {
        public TeatroContext(DbContextOptions<TeatroContext> options)
    : base(options)
        {

        }

        public DbSet<Actores> Actores { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Obras> Obras { get; set; }
        public DbSet<Sala> Salas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actores>().HasData(
                new Actores { ActorId = 1, Nombre = "Fernando" }
                );
            modelBuilder.Entity<Funciones>().HasData(
               new Funciones { FunciónID = 1, SalaID = 1, Fecha = new DateTime(2024, 2, 20), Hora = "20:00" }
                );
            modelBuilder.Entity<Obras>().HasData(
                new Obras { ObraID = 1, Titulo = "gfgrqe", Director = "gregrqe", Sinopsis = "gregq", Duración = "greqgre", Precio = 12, Imagen = "../assets/impulso.jpg" }
                );
            modelBuilder.Entity<Sala>().HasData(
                new Sala { SalaID = 1, Nombre = "gfgrqe", Capacidad = 120}
                );
        }
    }
}
