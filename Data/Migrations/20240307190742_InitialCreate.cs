using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duración = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraID);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroColumnas = table.Column<int>(type: "int", nullable: false),
                    NumeroFilas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "ObraActores",
                columns: table => new
                {
                    ObraID = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraActores", x => new { x.ObraID, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ObraActores_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObraActores_Obras_ObraID",
                        column: x => x.ObraID,
                        principalTable: "Obras",
                        principalColumn: "ObraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraID = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionID);
                    table.ForeignKey(
                        name: "FK_Funciones_Obras_ObraID",
                        column: x => x.ObraID,
                        principalTable: "Obras",
                        principalColumn: "ObraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunciónID = table.Column<int>(type: "int", nullable: true),
                    NumeroFila = table.Column<int>(type: "int", nullable: false),
                    NumeroColumna = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID");
                });

            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "ActorId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Palmira Cardo" },
                    { 2, "Aarón Doménech" },
                    { 3, "Daniela Fernanda" },
                    { 4, "María Gayubo" },
                    { 5, "Nuria Luna" },
                    { 6, "Marc Orero" },
                    { 7, "Pako Portalo" },
                    { 8, "María Sabaté" },
                    { 9, "Josie Sinnadurai" },
                    { 10, "Fernando Tejero" },
                    { 11, "Dani Muriel" },
                    { 12, "Mabel del Pozo" },
                    { 13, "Belén Rueda" },
                    { 14, "Luisa Martín" },
                    { 15, "Juan Fernández" },
                    { 16, "Pablo Puyol" },
                    { 17, "Sergio Mur" },
                    { 18, "Antonio Sansano" },
                    { 19, "Jorge Mayor" },
                    { 20, "José Fernández" },
                    { 21, "José de la Torre" },
                    { 22, "Christian Escuredo" },
                    { 23, "Dídac Flores" },
                    { 24, "Carmen Raigón" },
                    { 25, "Marta Valverde" },
                    { 26, "Chema Noci" },
                    { 27, "Fernando Cayo" },
                    { 28, "Belén Orihuela" },
                    { 29, "Julián Salguero" },
                    { 30, "Paris Martín" },
                    { 31, "Linda Estefanía Rocamora" },
                    { 32, "Javier del Arco" },
                    { 33, "Ángela Rucas" },
                    { 34, "Carmela Martins" },
                    { 35, "Raúl Heredia" },
                    { 36, "Nicolás Ojeda" },
                    { 37, "Asier Meléndez" },
                    { 38, "Nayeli Robert" },
                    { 39, "David García" },
                    { 40, "Samuel J. Nikana" },
                    { 41, "Leonardo Rabat Buila" },
                    { 42, "Yihao Luis Wu" },
                    { 43, "José David Kasparett Salcedo" },
                    { 44, "José Carlos Jiménez Carranza" },
                    { 45, "Silvestre Okuru" },
                    { 46, "Nguema Angue Somo" },
                    { 47, "Yichen Alex Wu" },
                    { 48, "Pablo Pérez Clergas" },
                    { 49, "Valentina Carrascón" },
                    { 50, "Minerva Carrascón" },
                    { 51, "Josema Yuste" },
                    { 52, "Javier Losán" },
                    { 53, "Santiago Urrialde" },
                    { 54, "Esther del Prado" },
                    { 55, "María Sánchez" },
                    { 56, "Javier Posadas" },
                    { 57, "Adrián Martín" },
                    { 58, "Víctor Linuesa" },
                    { 59, "Alejandro de la Fuente" }
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraID", "Director", "Duración", "Imagen", "Precio", "Sinopsis", "Titulo" },
                values: new object[,]
                {
                    { 1, "Boaz Berman", "90 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1209597906240147507/impulso.jpg?ex=65e780d6&is=65d50bd6&hm=87edcb468bd5850e48105c46ba67f5c3cd5698f3497ad004810f1426484517c9&=&format=webp&width=563&height=676", 12m, "Impulso cuenta la historia del viaje de la vida a través de la perspectiva del ritmo y el movimiento. El espectáculo explora los diferentes estados de la vida y las emociones que conviven en ella. El show se caracteriza por tener una mezcla ecléctica musical y rítmica de todas las partes del mundo, oscilando desde patrones que provienen de las percusiones tradicionales africanas, hasta beats electrónicos más contemporáneos. Los artistas conjugan cuerpo y mente como instrumentos, creando ritmos y movimientos hipnotizantes que dejan al espectador sin aliento. El latido o pulso es el tema central del espectáculo, representando el ritmo de la vida en sí mismo. Los artistas utilizan sus propios ritmos como punto de partida, construyendo ritmos y movimientos complejos que reflejan los momentos ascendentes y descendentes del viaje de la vida. Emociones y sensaciones: Impulso es un gaudeamus sensorial con colores vibrantes, movimientos dinámicos y acompasados ritmos que dejan al público completamente pletórico de energía e inspiración. El espectáculo captura todo un enorme abanico de emociones y experiencias humanas, que hacen de Impulso toda una fiesta del ritmo; un show cautivador que lleva al espectador a realizar un viaje a través de los ritmos de la vida.", "Impulso" },
                    { 2, "Juan Carlos Rubio", "105 minutos", "https://cdn.discordapp.com/attachments/1193559955001847920/1209597906542268477/caminoAlZoo.jpg?ex=65e780d6&is=65d50bd6&hm=7c6b5d492436dac2af1eb0913d44ffa8ec1619bf44d440bcfd9626c9660dbea2&", 16m, "A pesar de ser pareja, la vida cotidiana de Peter y Ann está marcada por la incomunicación y la soledad. Rehuyendo el intento de Ann por afrontar la situación, Peter decide pasar el día en el zoológicos de Central Park. Allí conocerá a Jerry, un excéntrico personaje que le obliga a escuchar sus historias hasta la última y más espeluznante de todas: el motivo real de su visita al zoo.", "Camino al Zoo" },
                    { 3, "Magüi Mira", "80 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1210266592341000192/salome.jpeg?ex=65e9ef99&is=65d77a99&hm=6eae7db6490a2e70e85bdd038e5d994f9db03e1fe3736e957d77dd2e30316a3c&=&format=webp&width=430&height=609", 25m, "Salomé es Historia. Historia brutal. Este cuento lo pueblan personas que han existido y se han cruzado en las calles. En los primero años del Siglo I de nuestra Era, los romanos continúan invadiendo las tierras que rodean el Mediterráneo. Colocan monarcas y dictadores salvajes para someter a sus gentes. Llegan a Judea; y allí una princesa, Salomé, apoya en secreto a los rebeldes que resisten al gobierno del Rey Herodes, un títere corrupto nombrado por Roma; un hombre sin moral que gobierna sin ley. Juan El Bautista, líder espiritual de su pueblo, grita contra el invasor y se descarna cautivo en la prisión del Palacio de Herodes. Da la vida por un Tiempo Nuevo. Es un Profeta; dice que la esperanza, el aliento de todos los sueños; y enciende el deseo de la Princesa. Salomé, perdida en la cabeza de su amado Juan El Bautista, sufre; rechazada por él se transforma en una mujer sangrante. Salomé, expresión del poder sensual absoluto, extrema su deseo por El Bautista; un deseo que se desborda en muerte. El amor y la muerte viven en un permanente abrazo y Salomé rompe la línea roja que la lleva al delirio. Inducida por su madre, la Reina Herodías, se atreve a pedir a su padrastro, el Rey, la cabeza del Bautista. Herodías es una mujer usada y abusada por el poder; una mujer con necesidad de libertad. Herodías va dando tumbos en una tierra de represiones que ignora y lapida a las mujeres si abandonan la estricta moral. Ella se arrastra por una vida imposible envuelta en sexo, en alcohol y desvaríos. Y más arriba Sirio, esa estrella, la más brillante del cielo, señal de vida sobre un planeta que se destruye de guerra en guerra y de dios en dios. Guerras armadas por los Herodes de hoy. Ayer y hoy en un mismo tiempo. Sirio, esa energía pura que nos puede transformar. Y abajo, en las profundidades de las cloacas, la Guardia Real, excremento del poder que se empeña en proteger al país de las mujeres ignorantes y viciosas. Tapan con velos sus cuerpos dejándolas sin existencia. El sexo tiene el poder de mover el mundo, amarlo y destruirlo. Y ese poder se llama Salomé.", "Salomé" },
                    { 4, "Juan Carlos Rubio", "100 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1210266590348714094/elNovioDeEspana.jpg?ex=65e9ef98&is=65d77a98&hm=41d00d59ba7d0370200afb39d98ae8df6238c67a4b5e3d033a020c931185137a&=&format=webp&width=431&height=609", 17m, "Nos encontramos en 1952. El internacionalmente conocido cantante vasco Luis Mariano se encuentra en España rodando Violetas Imperiales. Tras el enorme éxito de El Sueño de Andalucía y La Bella de Cádiz, la cantante y actriz Carmen Sevilla y él vuelven a protagonizar una película musical. Entre los dos existe una entrañable amistad que ambos saben que no puede convertirse en amor, dadas las evidentes preferencias sexuales del cantante. Pero Luis Mariano está dispuesto a «heterosexualizar» su imagen, zanjar las habladurías y pedir a la actriz andaluza que se case con él. Se convertirá en un «hombre de verdad». Carmen Sevilla no comprende la repentina ansiedad de Luis Mariano por «normalizar» su vida. Y es que el tenor esconde una poderosa razón: sus padres, republicanos exiliados al comienzo de la Guerra Civil, quieren regresar a España. Y él desea pedirle a Franco que se lo permita, renovando sus pasaporte. Y si para alcanzar ese fin ha de renunciar a su verdadera condición sexual, está dispuesto a todo. La actriz se niega a participar en un matrimonio de conveniencia, pero promete ayudarle a conseguir sus objetivos. El 18 de julio, Franco dará su tradicional fiesta en el Palacio de La Granja. ¿No es ese el momento perfecto para que Luis Mariano pueda conseguir su objetivo?", "El novio de España" },
                    { 5, "Mingo Ruano", "75 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1210266589857841152/cuentoDeNavidad.jpg?ex=65e9ef98&is=65d77a98&hm=37161ae32fc01a46296aa1e7bfebc2047d9bc535da97509437960c735e283de6&=&format=webp&width=440&height=609", 12m, "Cuento de Navidad, el clásico de Charles Dickens se presenta en una versión que ambienta la acción en el Londres de los años 30. El Sr. Ebenezer Scrooge un hombre avaro, tacaño y solitario, que nunca celebra la Navidad, recibe la visita del fantasma de su antiguo socio, muerto años atrás. Éste le cuenta que, por haber sido avaro en la vida, toda su maldad se ha convertido en una larga y pesada cadena que deberá arrastrar para siempre. Le anuncia que le espera un destino aún peor, y le avisa de que tendrá una última oportunidad de cambiar cuando reciba la visita de los tres Espíritus de la Navidad. El Sr. Scrooge desafiando la predicción, no se asusta por la noticia y esa noche aparecen los tres Espíritus Navideños: el Pasado, que le hace recordar su vida infantil y juvenil llena de melancolía y añoranza, antes de su adicción al trabajo y su desmedido afán por el dinero; el del Presente que le hace ver la actual situación de la familia de su empleado Bob, que a pesar de su pobreza y de la enfermedad de su hijo Tim, celebra la Navidad. El terrible y sombrío espíritu del Futuro le muestra el destino que le deparará su vida enfrentándose al saqueo de su casa por los pobres, la muerte del pequeño Tim y lo más espantoso: su propia tumba, ante la cual el Sr. Scrooge se horroriza de tal forma que suplica una nueva oportunidad para cambiar. El avaro despierta de su pesadilla y se convierte en un hombre generoso y amable, que celebra la Navidad y ayuda a quienes le rodean.", "Cuento de Navidad" },
                    { 6, "Josema Yuste", "95 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1210266591628103740/queDiosNoNosPille.jpg?ex=65e9ef99&is=65d77a99&hm=8ab3a9eee0fe2cb99e876e1223216b947d4e22b2441c4b20df7792b09ec85d07&=&format=webp", 17m, "El padre Beltrán (Josema Yuste) visita a la marquesa Pilar (Esther del Prado), que posee un valioso cuadro del siglo XVII. El inspector (Santiago Urrialde) ha chequeado las medidas de seguridad y descarta que un ladrón pueda llevárselo. Pero al sacerdote no se le escapa una, y sospecha que el fontanero Floren (Javier Losán) está planeando un robo. Chapucero, sí, pero robo al fin y al cabo... ¡Bienaventurados los espectadores de esta comedia! Pues ellos disfrutarán de un enredo con sospechas, polis, cacos, amor, estafas, tentaciones y hasta un cirio... Aquí todos tienen pecados que ocultar... y siempre será mejor... Que Dios nos pille confesados.", "Que Dios nos pille confesados" },
                    { 7, "Javier Posadas", "120 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1210266591220998305/losCadaveresNoHablan.jpg?ex=65e9ef99&is=65d77a99&hm=66334ef69feb8982b4620390df4ec2388a0a9995b72c96774156c8a17edb35a1&=&format=webp", 16m, "El Marqués de Milford Haven Se ha suicidado en su habitación con las puertas y las ventanas cerradas por dentro. ¿Realmente se suicidó, o fue un asesinato? Juega tu papel, atiende a las escenas y habla con los actores para descubrir el misterio que rodea la muerte del Marqués.", "Los cadáveres no hablan" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "FunciónID", "NumeroColumna", "NumeroFila", "SalaID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null },
                    { 2, 1, 6, 7, null }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "Nombre", "NumeroColumnas", "NumeroFilas" },
                values: new object[,]
                {
                    { 1, "Sala 1", 9, 10 },
                    { 2, "Sala 2", 14, 6 },
                    { 3, "Sala 3", 8, 9 },
                    { 4, "Sala 4", 12, 8 },
                    { 5, "Sala 5", 7, 12 },
                    { 6, "Sala 6", 13, 12 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Contraseña", "IsAdmin", "Nombre", "NombreUsuario" },
                values: new object[] { 1, "1234", true, "Diego Gimenez Sancho", "17diego15" });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionID", "Disponibilidad", "Fecha", "Hora", "ObraID", "SalaID" },
                values: new object[,]
                {
                    { 1, "Si", new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 1, 3 },
                    { 2, "Si", new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 1, 4 },
                    { 3, "Si", new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 1, 6 },
                    { 4, "Si", new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 1, 2 },
                    { 5, "Si", new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 1, 6 },
                    { 6, "Si", new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 1, 5 },
                    { 7, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 1, 2 },
                    { 8, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 1, 5 },
                    { 9, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 2, 6 },
                    { 10, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 2, 2 },
                    { 11, "Si", new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 2, 3 },
                    { 12, "Si", new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 2, 1 },
                    { 13, "Si", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 2, 2 },
                    { 14, "Si", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 2, 1 },
                    { 15, "Si", new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 3, 1 },
                    { 16, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 3, 3 },
                    { 17, "Si", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 3, 2 },
                    { 18, "Si", new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 4, 4 },
                    { 19, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 4, 6 },
                    { 20, "Si", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 4, 5 },
                    { 21, "Si", new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 5, 2 },
                    { 22, "Si", new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 5, 1 },
                    { 23, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 5, 5 },
                    { 24, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 6, 2 },
                    { 25, "Si", new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:00", 6, 4 },
                    { 26, "Si", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 6, 3 },
                    { 27, "Si", new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "10:00", 6, 6 },
                    { 28, "Si", new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "10:00", 6, 4 },
                    { 29, "Si", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "16:00", 6, 2 },
                    { 30, "Si", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "ObraActores",
                columns: new[] { "ActorId", "ObraID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 19, 3 },
                    { 20, 3 },
                    { 21, 3 },
                    { 22, 4 },
                    { 23, 4 },
                    { 24, 4 },
                    { 25, 4 },
                    { 26, 4 },
                    { 27, 5 },
                    { 28, 5 },
                    { 29, 5 },
                    { 30, 5 },
                    { 31, 5 },
                    { 32, 5 },
                    { 33, 5 },
                    { 34, 5 },
                    { 35, 5 },
                    { 36, 5 },
                    { 37, 5 },
                    { 38, 5 },
                    { 39, 5 },
                    { 40, 5 },
                    { 41, 5 },
                    { 42, 5 },
                    { 43, 5 },
                    { 44, 5 },
                    { 45, 5 },
                    { 46, 5 },
                    { 47, 5 },
                    { 48, 5 },
                    { 49, 5 },
                    { 50, 5 },
                    { 51, 6 },
                    { 52, 6 },
                    { 53, 6 },
                    { 54, 6 },
                    { 55, 7 },
                    { 56, 7 },
                    { 57, 7 },
                    { 58, 7 },
                    { 59, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_ObraID",
                table: "Funciones",
                column: "ObraID");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaID",
                table: "Funciones",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObraActores_ActorId",
                table: "ObraActores",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_SalaID",
                table: "Reservas",
                column: "SalaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "ObraActores");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
