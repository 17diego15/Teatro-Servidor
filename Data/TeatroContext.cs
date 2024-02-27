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

        public DbSet<Actor> Actores { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ObraActor> ObraActores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ObraActor>()
                .HasKey(oa => new { oa.ObraID, oa.ActorId });

            modelBuilder.Entity<ObraActor>()
                .HasOne(oa => oa.Obra)
                .WithMany(o => o.ObraActores)
                .HasForeignKey(oa => oa.ObraID);

            modelBuilder.Entity<ObraActor>()
                .HasOne(oa => oa.Actor)
                .WithMany(a => a.ObraActores)
                .HasForeignKey(oa => oa.ActorId);

            modelBuilder.Entity<Funcion>()
                    .HasKey(f => f.FuncionID);

            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.Obra)
                .WithMany(o => o.Funciones)
                .HasForeignKey(f => f.ObraID);

            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.Sala)
                .WithMany(s => s.Funciones)
                .HasForeignKey(f => f.SalaID);

            modelBuilder.Entity<Actor>().HasData(
                new Actor { ActorId = 1, Nombre = "Palmira Cardo" },
                new Actor { ActorId = 2, Nombre = "Aarón Doménech" },
                new Actor { ActorId = 3, Nombre = "Daniela Fernanda" },
                new Actor { ActorId = 4, Nombre = "María Gayubo" },
                new Actor { ActorId = 5, Nombre = "Nuria Luna" },
                new Actor { ActorId = 6, Nombre = "Marc Orero" },
                new Actor { ActorId = 7, Nombre = "Pako Portalo" },
                new Actor { ActorId = 8, Nombre = "María Sabaté" },
                new Actor { ActorId = 9, Nombre = "Josie Sinnadurai" },
                new Actor { ActorId = 10, Nombre = "Fernando Tejero" },
                new Actor { ActorId = 11, Nombre = "Dani Muriel" },
                new Actor { ActorId = 12, Nombre = "Mabel del Pozo" },
                new Actor { ActorId = 13, Nombre = "Belén Rueda" },
                new Actor { ActorId = 14, Nombre = "Luisa Martín" },
                new Actor { ActorId = 15, Nombre = "Juan Fernández" },
                new Actor { ActorId = 16, Nombre = "Pablo Puyol" },
                new Actor { ActorId = 17, Nombre = "Sergio Mur" },
                new Actor { ActorId = 18, Nombre = "Antonio Sansano" },
                new Actor { ActorId = 19, Nombre = "Jorge Mayor" },
                new Actor { ActorId = 20, Nombre = "José Fernández" },
                new Actor { ActorId = 21, Nombre = "José de la Torre" },
                new Actor { ActorId = 22, Nombre = "Christian Escuredo" },
                new Actor { ActorId = 23, Nombre = "Dídac Flores" },
                new Actor { ActorId = 24, Nombre = "Carmen Raigón" },
                new Actor { ActorId = 25, Nombre = "Marta Valverde" },
                new Actor { ActorId = 26, Nombre = "Chema Noci" },
                new Actor { ActorId = 27, Nombre = "Fernando Cayo" },
                new Actor { ActorId = 28, Nombre = "Belén Orihuela" },
                new Actor { ActorId = 29, Nombre = "Julián Salguero" },
                new Actor { ActorId = 30, Nombre = "Paris Martín" },
                new Actor { ActorId = 31, Nombre = "Linda Estefanía Rocamora" },
                new Actor { ActorId = 32, Nombre = "Javier del Arco" },
                new Actor { ActorId = 33, Nombre = "Ángela Rucas" },
                new Actor { ActorId = 34, Nombre = "Carmela Martins" },
                new Actor { ActorId = 35, Nombre = "Raúl Heredia" },
                new Actor { ActorId = 36, Nombre = "Nicolás Ojeda" },
                new Actor { ActorId = 37, Nombre = "Asier Meléndez" },
                new Actor { ActorId = 38, Nombre = "Nayeli Robert" },
                new Actor { ActorId = 39, Nombre = "David García" },
                new Actor { ActorId = 40, Nombre = "Samuel J. Nikana" },
                new Actor { ActorId = 41, Nombre = "Leonardo Rabat Buila" },
                new Actor { ActorId = 42, Nombre = "Yihao Luis Wu" },
                new Actor { ActorId = 43, Nombre = "José David Kasparett Salcedo" },
                new Actor { ActorId = 44, Nombre = "José Carlos Jiménez Carranza" },
                new Actor { ActorId = 45, Nombre = "Silvestre Okuru" },
                new Actor { ActorId = 46, Nombre = "Nguema Angue Somo" },
                new Actor { ActorId = 47, Nombre = "Yichen Alex Wu" },
                new Actor { ActorId = 48, Nombre = "Pablo Pérez Clergas" },
                new Actor { ActorId = 49, Nombre = "Valentina Carrascón" },
                new Actor { ActorId = 50, Nombre = "Minerva Carrascón" },
                new Actor { ActorId = 51, Nombre = "Josema Yuste" },
                new Actor { ActorId = 52, Nombre = "Javier Losán" },
                new Actor { ActorId = 53, Nombre = "Santiago Urrialde" },
                new Actor { ActorId = 54, Nombre = "Esther del Prado" },
                new Actor { ActorId = 55, Nombre = "María Sánchez" },
                new Actor { ActorId = 56, Nombre = "Javier Posadas" },
                new Actor { ActorId = 57, Nombre = "Adrián Martín" },
                new Actor { ActorId = 58, Nombre = "Víctor Linuesa" },
                new Actor { ActorId = 59, Nombre = "Alejandro de la Fuente" }
                );
            modelBuilder.Entity<Funcion>().HasData(
                new Funcion { FuncionID = 1, ObraID = 1, SalaID = 3, Fecha = new DateTime(2023, 12, 11), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 2, ObraID = 1, SalaID = 4, Fecha = new DateTime(2023, 12, 11), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 3, ObraID = 1, SalaID = 6, Fecha = new DateTime(2023, 12, 11), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 4, ObraID = 1, SalaID = 2, Fecha = new DateTime(2023, 12, 12), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 5, ObraID = 1, SalaID = 6, Fecha = new DateTime(2023, 12, 13), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 6, ObraID = 1, SalaID = 5, Fecha = new DateTime(2023, 12, 14), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 7, ObraID = 1, SalaID = 2, Fecha = new DateTime(2023, 12, 15), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 8, ObraID = 1, SalaID = 5, Fecha = new DateTime(2023, 12, 15), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 9, ObraID = 2, SalaID = 6, Fecha = new DateTime(2023, 12, 15), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 10, ObraID = 2, SalaID = 2, Fecha = new DateTime(2023, 12, 15), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 11, ObraID = 2, SalaID = 3, Fecha = new DateTime(2023, 12, 16), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 12, ObraID = 2, SalaID = 1, Fecha = new DateTime(2023, 12, 16), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 13, ObraID = 2, SalaID = 2, Fecha = new DateTime(2023, 12, 17), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 14, ObraID = 2, SalaID = 1, Fecha = new DateTime(2023, 12, 17), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 15, ObraID = 3, SalaID = 1, Fecha = new DateTime(2023, 12, 13), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 16, ObraID = 3, SalaID = 3, Fecha = new DateTime(2023, 12, 15), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 17, ObraID = 3, SalaID = 2, Fecha = new DateTime(2023, 12, 17), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 18, ObraID = 4, SalaID = 4, Fecha = new DateTime(2023, 12, 13), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 19, ObraID = 4, SalaID = 6, Fecha = new DateTime(2023, 12, 15), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 20, ObraID = 4, SalaID = 5, Fecha = new DateTime(2023, 12, 17), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 21, ObraID = 5, SalaID = 2, Fecha = new DateTime(2023, 12, 11), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 22, ObraID = 5, SalaID = 1, Fecha = new DateTime(2023, 12, 13), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 23, ObraID = 5, SalaID = 5, Fecha = new DateTime(2023, 12, 15), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 24, ObraID = 6, SalaID = 2, Fecha = new DateTime(2023, 12, 15), Hora = "20:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 25, ObraID = 6, SalaID = 4, Fecha = new DateTime(2023, 12, 16), Hora = "18:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 26, ObraID = 6, SalaID = 3, Fecha = new DateTime(2023, 12, 17), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 27, ObraID = 6, SalaID = 6, Fecha = new DateTime(2023, 12, 18), Hora = "10:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 28, ObraID = 6, SalaID = 4, Fecha = new DateTime(2023, 12, 19), Hora = "11:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 29, ObraID = 6, SalaID = 2, Fecha = new DateTime(2023, 12, 20), Hora = "16:00", Disponibilidad = "Si" },
                new Funcion { FuncionID = 30, ObraID = 7, SalaID = 5, Fecha = new DateTime(2023, 12, 15), Hora = "20:00", Disponibilidad = "Si" }

                );
            modelBuilder.Entity<Obra>().HasData(
                new Obra { ObraID = 1, Titulo = "Impulso", Director = "Boaz Berman", Sinopsis = "Impulso cuenta la historia del viaje de la vida a través de la perspectiva del ritmo y el movimiento. El espectáculo explora los diferentes estados de la vida y las emociones que conviven en ella. El show se caracteriza por tener una mezcla ecléctica musical y rítmica de todas las partes del mundo, oscilando desde patrones que provienen de las percusiones tradicionales africanas, hasta beats electrónicos más contemporáneos. Los artistas conjugan cuerpo y mente como instrumentos, creando ritmos y movimientos hipnotizantes que dejan al espectador sin aliento. El latido o pulso es el tema central del espectáculo, representando el ritmo de la vida en sí mismo. Los artistas utilizan sus propios ritmos como punto de partida, construyendo ritmos y movimientos complejos que reflejan los momentos ascendentes y descendentes del viaje de la vida. Emociones y sensaciones: Impulso es un gaudeamus sensorial con colores vibrantes, movimientos dinámicos y acompasados ritmos que dejan al público completamente pletórico de energía e inspiración. El espectáculo captura todo un enorme abanico de emociones y experiencias humanas, que hacen de Impulso toda una fiesta del ritmo; un show cautivador que lleva al espectador a realizar un viaje a través de los ritmos de la vida.", Duración = "90 minutos", Precio = 12, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1209597906240147507/impulso.jpg?ex=65e780d6&is=65d50bd6&hm=87edcb468bd5850e48105c46ba67f5c3cd5698f3497ad004810f1426484517c9&=&format=webp&width=563&height=676" },
                new Obra { ObraID = 2, Titulo = "Camino al Zoo", Director = "Juan Carlos Rubio", Sinopsis = "A pesar de ser pareja, la vida cotidiana de Peter y Ann está marcada por la incomunicación y la soledad. Rehuyendo el intento de Ann por afrontar la situación, Peter decide pasar el día en el zoológicos de Central Park. Allí conocerá a Jerry, un excéntrico personaje que le obliga a escuchar sus historias hasta la última y más espeluznante de todas: el motivo real de su visita al zoo.", Duración = "105 minutos", Precio = 16, Imagen = "https://cdn.discordapp.com/attachments/1193559955001847920/1209597906542268477/caminoAlZoo.jpg?ex=65e780d6&is=65d50bd6&hm=7c6b5d492436dac2af1eb0913d44ffa8ec1619bf44d440bcfd9626c9660dbea2&" },
                new Obra { ObraID = 3, Titulo = "Salomé", Director = "Magüi Mira", Sinopsis = "Salomé es Historia. Historia brutal. Este cuento lo pueblan personas que han existido y se han cruzado en las calles. En los primero años del Siglo I de nuestra Era, los romanos continúan invadiendo las tierras que rodean el Mediterráneo. Colocan monarcas y dictadores salvajes para someter a sus gentes. Llegan a Judea; y allí una princesa, Salomé, apoya en secreto a los rebeldes que resisten al gobierno del Rey Herodes, un títere corrupto nombrado por Roma; un hombre sin moral que gobierna sin ley. Juan El Bautista, líder espiritual de su pueblo, grita contra el invasor y se descarna cautivo en la prisión del Palacio de Herodes. Da la vida por un Tiempo Nuevo. Es un Profeta; dice que la esperanza, el aliento de todos los sueños; y enciende el deseo de la Princesa. Salomé, perdida en la cabeza de su amado Juan El Bautista, sufre; rechazada por él se transforma en una mujer sangrante. Salomé, expresión del poder sensual absoluto, extrema su deseo por El Bautista; un deseo que se desborda en muerte. El amor y la muerte viven en un permanente abrazo y Salomé rompe la línea roja que la lleva al delirio. Inducida por su madre, la Reina Herodías, se atreve a pedir a su padrastro, el Rey, la cabeza del Bautista. Herodías es una mujer usada y abusada por el poder; una mujer con necesidad de libertad. Herodías va dando tumbos en una tierra de represiones que ignora y lapida a las mujeres si abandonan la estricta moral. Ella se arrastra por una vida imposible envuelta en sexo, en alcohol y desvaríos. Y más arriba Sirio, esa estrella, la más brillante del cielo, señal de vida sobre un planeta que se destruye de guerra en guerra y de dios en dios. Guerras armadas por los Herodes de hoy. Ayer y hoy en un mismo tiempo. Sirio, esa energía pura que nos puede transformar. Y abajo, en las profundidades de las cloacas, la Guardia Real, excremento del poder que se empeña en proteger al país de las mujeres ignorantes y viciosas. Tapan con velos sus cuerpos dejándolas sin existencia. El sexo tiene el poder de mover el mundo, amarlo y destruirlo. Y ese poder se llama Salomé.", Duración = "80 minutos", Precio = 25, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1210266592341000192/salome.jpeg?ex=65e9ef99&is=65d77a99&hm=6eae7db6490a2e70e85bdd038e5d994f9db03e1fe3736e957d77dd2e30316a3c&=&format=webp&width=430&height=609" },
                new Obra { ObraID = 4, Titulo = "El novio de España", Director = "Juan Carlos Rubio", Sinopsis = "Nos encontramos en 1952. El internacionalmente conocido cantante vasco Luis Mariano se encuentra en España rodando Violetas Imperiales. Tras el enorme éxito de El Sueño de Andalucía y La Bella de Cádiz, la cantante y actriz Carmen Sevilla y él vuelven a protagonizar una película musical. Entre los dos existe una entrañable amistad que ambos saben que no puede convertirse en amor, dadas las evidentes preferencias sexuales del cantante. Pero Luis Mariano está dispuesto a «heterosexualizar» su imagen, zanjar las habladurías y pedir a la actriz andaluza que se case con él. Se convertirá en un «hombre de verdad». Carmen Sevilla no comprende la repentina ansiedad de Luis Mariano por «normalizar» su vida. Y es que el tenor esconde una poderosa razón: sus padres, republicanos exiliados al comienzo de la Guerra Civil, quieren regresar a España. Y él desea pedirle a Franco que se lo permita, renovando sus pasaporte. Y si para alcanzar ese fin ha de renunciar a su verdadera condición sexual, está dispuesto a todo. La actriz se niega a participar en un matrimonio de conveniencia, pero promete ayudarle a conseguir sus objetivos. El 18 de julio, Franco dará su tradicional fiesta en el Palacio de La Granja. ¿No es ese el momento perfecto para que Luis Mariano pueda conseguir su objetivo?", Duración = "100 minutos", Precio = 17, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1210266590348714094/elNovioDeEspana.jpg?ex=65e9ef98&is=65d77a98&hm=41d00d59ba7d0370200afb39d98ae8df6238c67a4b5e3d033a020c931185137a&=&format=webp&width=431&height=609" },
                new Obra { ObraID = 5, Titulo = "Cuento de Navidad", Director = "Mingo Ruano", Sinopsis = "Cuento de Navidad, el clásico de Charles Dickens se presenta en una versión que ambienta la acción en el Londres de los años 30. El Sr. Ebenezer Scrooge un hombre avaro, tacaño y solitario, que nunca celebra la Navidad, recibe la visita del fantasma de su antiguo socio, muerto años atrás. Éste le cuenta que, por haber sido avaro en la vida, toda su maldad se ha convertido en una larga y pesada cadena que deberá arrastrar para siempre. Le anuncia que le espera un destino aún peor, y le avisa de que tendrá una última oportunidad de cambiar cuando reciba la visita de los tres Espíritus de la Navidad. El Sr. Scrooge desafiando la predicción, no se asusta por la noticia y esa noche aparecen los tres Espíritus Navideños: el Pasado, que le hace recordar su vida infantil y juvenil llena de melancolía y añoranza, antes de su adicción al trabajo y su desmedido afán por el dinero; el del Presente que le hace ver la actual situación de la familia de su empleado Bob, que a pesar de su pobreza y de la enfermedad de su hijo Tim, celebra la Navidad. El terrible y sombrío espíritu del Futuro le muestra el destino que le deparará su vida enfrentándose al saqueo de su casa por los pobres, la muerte del pequeño Tim y lo más espantoso: su propia tumba, ante la cual el Sr. Scrooge se horroriza de tal forma que suplica una nueva oportunidad para cambiar. El avaro despierta de su pesadilla y se convierte en un hombre generoso y amable, que celebra la Navidad y ayuda a quienes le rodean.", Duración = "75 minutos", Precio = 12, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1210266589857841152/cuentoDeNavidad.jpg?ex=65e9ef98&is=65d77a98&hm=37161ae32fc01a46296aa1e7bfebc2047d9bc535da97509437960c735e283de6&=&format=webp&width=440&height=609" },
                new Obra { ObraID = 6, Titulo = "Que Dios nos pille confesados", Director = "Josema Yuste", Sinopsis = "El padre Beltrán (Josema Yuste) visita a la marquesa Pilar (Esther del Prado), que posee un valioso cuadro del siglo XVII. El inspector (Santiago Urrialde) ha chequeado las medidas de seguridad y descarta que un ladrón pueda llevárselo. Pero al sacerdote no se le escapa una, y sospecha que el fontanero Floren (Javier Losán) está planeando un robo. Chapucero, sí, pero robo al fin y al cabo... ¡Bienaventurados los espectadores de esta comedia! Pues ellos disfrutarán de un enredo con sospechas, polis, cacos, amor, estafas, tentaciones y hasta un cirio... Aquí todos tienen pecados que ocultar... y siempre será mejor... Que Dios nos pille confesados.", Duración = "95 minutos", Precio = 17, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1210266591628103740/queDiosNoNosPille.jpg?ex=65e9ef99&is=65d77a99&hm=8ab3a9eee0fe2cb99e876e1223216b947d4e22b2441c4b20df7792b09ec85d07&=&format=webp" },
                new Obra { ObraID = 7, Titulo = "Los cadáveres no hablan", Director = "Javier Posadas", Sinopsis = "El Marqués de Milford Haven Se ha suicidado en su habitación con las puertas y las ventanas cerradas por dentro. ¿Realmente se suicidó, o fue un asesinato? Juega tu papel, atiende a las escenas y habla con los actores para descubrir el misterio que rodea la muerte del Marqués.", Duración = "120 minutos", Precio = 16, Imagen = "https://media.discordapp.net/attachments/1193559955001847920/1210266591220998305/losCadaveresNoHablan.jpg?ex=65e9ef99&is=65d77a99&hm=66334ef69feb8982b4620390df4ec2388a0a9995b72c96774156c8a17edb35a1&=&format=webp" }
                );
            modelBuilder.Entity<Sala>().HasData(
                new Sala { SalaID = 1, Nombre = "Sala 1", Capacidad = 120 },
                new Sala { SalaID = 2, Nombre = "Sala 2", Capacidad = 120 },
                new Sala { SalaID = 3, Nombre = "Sala 3", Capacidad = 120 },
                new Sala { SalaID = 4, Nombre = "Sala 4", Capacidad = 120 },
                new Sala { SalaID = 5, Nombre = "Sala 5", Capacidad = 120 },
                new Sala { SalaID = 6, Nombre = "Sala 6", Capacidad = 120 }
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { UsuarioID = 1, Nombre = "Diego Gimenez Sancho", NombreUsuario = "17diego15", Contraseña = "1234", IsAdmin = true }
                );

            modelBuilder.Entity<ObraActor>().HasData(
                new ObraActor { ActorId = 1, ObraID = 1 },
                new ObraActor { ActorId = 2, ObraID = 1 },
                new ObraActor { ActorId = 3, ObraID = 1 },
                new ObraActor { ActorId = 4, ObraID = 1 },
                new ObraActor { ActorId = 5, ObraID = 1 },
                new ObraActor { ActorId = 6, ObraID = 1 },
                new ObraActor { ActorId = 7, ObraID = 1 },
                new ObraActor { ActorId = 8, ObraID = 1 },
                new ObraActor { ActorId = 9, ObraID = 1 },
                new ObraActor { ActorId = 10, ObraID = 2 },
                new ObraActor { ActorId = 11, ObraID = 2 },
                new ObraActor { ActorId = 12, ObraID = 2 },
                new ObraActor { ActorId = 13, ObraID = 3 },
                new ObraActor { ActorId = 14, ObraID = 3 },
                new ObraActor { ActorId = 15, ObraID = 3 },
                new ObraActor { ActorId = 16, ObraID = 3 },
                new ObraActor { ActorId = 17, ObraID = 3 },
                new ObraActor { ActorId = 18, ObraID = 3 },
                new ObraActor { ActorId = 19, ObraID = 3 },
                new ObraActor { ActorId = 20, ObraID = 3 },
                new ObraActor { ActorId = 21, ObraID = 3 },
                new ObraActor { ActorId = 22, ObraID = 4 },
                new ObraActor { ActorId = 23, ObraID = 4 },
                new ObraActor { ActorId = 24, ObraID = 4 },
                new ObraActor { ActorId = 25, ObraID = 4 },
                new ObraActor { ActorId = 26, ObraID = 4 },
                new ObraActor { ActorId = 27, ObraID = 5 },
                new ObraActor { ActorId = 28, ObraID = 5 },
                new ObraActor { ActorId = 29, ObraID = 5 },
                new ObraActor { ActorId = 30, ObraID = 5 },
                new ObraActor { ActorId = 31, ObraID = 5 },
                new ObraActor { ActorId = 32, ObraID = 5 },
                new ObraActor { ActorId = 33, ObraID = 5 },
                new ObraActor { ActorId = 34, ObraID = 5 },
                new ObraActor { ActorId = 35, ObraID = 5 },
                new ObraActor { ActorId = 36, ObraID = 5 },
                new ObraActor { ActorId = 37, ObraID = 5 },
                new ObraActor { ActorId = 38, ObraID = 5 },
                new ObraActor { ActorId = 39, ObraID = 5 },
                new ObraActor { ActorId = 40, ObraID = 5 },
                new ObraActor { ActorId = 41, ObraID = 5 },
                new ObraActor { ActorId = 42, ObraID = 5 },
                new ObraActor { ActorId = 43, ObraID = 5 },
                new ObraActor { ActorId = 44, ObraID = 5 },
                new ObraActor { ActorId = 45, ObraID = 5 },
                new ObraActor { ActorId = 46, ObraID = 5 },
                new ObraActor { ActorId = 47, ObraID = 5 },
                new ObraActor { ActorId = 48, ObraID = 5 },
                new ObraActor { ActorId = 49, ObraID = 5 },
                new ObraActor { ActorId = 50, ObraID = 5 },
                new ObraActor { ActorId = 51, ObraID = 6 },
                new ObraActor { ActorId = 52, ObraID = 6 },
                new ObraActor { ActorId = 53, ObraID = 6 },
                new ObraActor { ActorId = 54, ObraID = 6 },
                new ObraActor { ActorId = 55, ObraID = 7 },
                new ObraActor { ActorId = 56, ObraID = 7 },
                new ObraActor { ActorId = 57, ObraID = 7 },
                new ObraActor { ActorId = 58, ObraID = 7 },
                new ObraActor { ActorId = 59, ObraID = 7 }
                );
        }
    }
}
