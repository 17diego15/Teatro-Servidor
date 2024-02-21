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
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actores>().HasData(
                new Actores { ActorId = 1, Nombre = "Fernando" }
                );
            modelBuilder.Entity<Funciones>().HasData(
               new Funciones { FunciónID = 1, SalaID = 1, Fecha = new DateTime(2024, 2, 20), Hora = "20:00", Desponibilidad = "Si" }
                );
            modelBuilder.Entity<Obras>().HasData(
                new Obras { ObraID = 1, Titulo = "Impulso", Director = "Boaz Berman", Sinopsis = "Impulso cuenta la historia del viaje de la vida a través de la perspectiva del ritmo y el movimiento. El espectáculo explora los diferentes estados de la vida y las emociones que conviven en ella. El show se caracteriza por tener una mezcla ecléctica musical y rítmica de todas las partes del mundo, oscilando desde patrones que provienen de las percusiones tradicionales africanas, hasta beats electrónicos más contemporáneos. Los artistas conjugan cuerpo y mente como instrumentos, creando ritmos y movimientos hipnotizantes que dejan al espectador sin aliento. El latido o pulso es el tema central del espectáculo, representando el ritmo de la vida en sí mismo. Los artistas utilizan sus propios ritmos como punto de partida, construyendo ritmos y movimientos complejos que reflejan los momentos ascendentes y descendentes del viaje de la vida. Emociones y sensaciones: Impulso es un gaudeamus sensorial con colores vibrantes, movimientos dinámicos y acompasados ritmos que dejan al público completamente pletórico de energía e inspiración. El espectáculo captura todo un enorme abanico de emociones y experiencias humanas, que hacen de Impulso toda una fiesta del ritmo; un show cautivador que lleva al espectador a realizar un viaje a través de los ritmos de la vida.", Duración = "90 minutos", Precio = 12, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1209597906240147507/impulso.jpg?ex=65e780d6&is=65d50bd6&hm=87edcb468bd5850e48105c46ba67f5c3cd5698f3497ad004810f1426484517c9&=&format=webp&width=563&height=676" },
                new Obras { ObraID = 2, Titulo = "Camino al Zoo", Director = "Juan Carlos Rubio", Sinopsis = "A pesar de ser pareja, la vida cotidiana de Peter y Ann está marcada por la incomunicación y la soledad. Rehuyendo el intento de Ann por afrontar la situación, Peter decide pasar el día en el zoológicos de Central Park. Allí conocerá a Jerry, un excéntrico personaje que le obliga a escuchar sus historias hasta la última y más espeluznante de todas: el motivo real de su visita al zoo.", Duración = "105 minutos", Precio = 16, Imagen = "https://cdn.discordapp.com/attachments/1193559955001847920/1209597906542268477/caminoAlZoo.jpg?ex=65e780d6&is=65d50bd6&hm=7c6b5d492436dac2af1eb0913d44ffa8ec1619bf44d440bcfd9626c9660dbea2&" }
                );
            modelBuilder.Entity<Sala>().HasData(
                new Sala { SalaID = 1, Nombre = "Sala 1", Capacidad = 120 }
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { UsuarioID = 1, Nombre = "Diego Gimenez Sancho", NombreUsuario = "17diego15", Contraseña = "1234", IsAdmin = true }
                );
        }
    }
}
