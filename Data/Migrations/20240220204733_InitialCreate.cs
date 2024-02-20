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
                name: "Funciones",
                columns: table => new
                {
                    FunciónID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FunciónID);
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
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "ActorId", "Nombre" },
                values: new object[] { 1, "Fernando" });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FunciónID", "Fecha", "Hora", "SalaID" },
                values: new object[] { 1, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "20:00", 1 });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraID", "Director", "Duración", "Imagen", "Precio", "Sinopsis", "Titulo" },
                values: new object[,]
                {
                    { 1, "Boaz Berman", "90 minutos", "https://media.discordapp.net/attachments/1193559955001847920/1209597906240147507/impulso.jpg?ex=65e780d6&is=65d50bd6&hm=87edcb468bd5850e48105c46ba67f5c3cd5698f3497ad004810f1426484517c9&=&format=webp&width=563&height=676", 12m, "Impulso cuenta la historia del viaje de la vida a través de la perspectiva del ritmo y el movimiento. El espectáculo explora los diferentes estados de la vida y las emociones que conviven en ella. El show se caracteriza por tener una mezcla ecléctica musical y rítmica de todas las partes del mundo, oscilando desde patrones que provienen de las percusiones tradicionales africanas, hasta beats electrónicos más contemporáneos. Los artistas conjugan cuerpo y mente como instrumentos, creando ritmos y movimientos hipnotizantes que dejan al espectador sin aliento. El latido o pulso es el tema central del espectáculo, representando el ritmo de la vida en sí mismo. Los artistas utilizan sus propios ritmos como punto de partida, construyendo ritmos y movimientos complejos que reflejan los momentos ascendentes y descendentes del viaje de la vida. Emociones y sensaciones: Impulso es un gaudeamus sensorial con colores vibrantes, movimientos dinámicos y acompasados ritmos que dejan al público completamente pletórico de energía e inspiración. El espectáculo captura todo un enorme abanico de emociones y experiencias humanas, que hacen de Impulso toda una fiesta del ritmo; un show cautivador que lleva al espectador a realizar un viaje a través de los ritmos de la vida.", "Impulso" },
                    { 2, "Juan Carlos Rubio", "105 minutos", "https://cdn.discordapp.com/attachments/1193559955001847920/1209597906542268477/caminoAlZoo.jpg?ex=65e780d6&is=65d50bd6&hm=7c6b5d492436dac2af1eb0913d44ffa8ec1619bf44d440bcfd9626c9660dbea2&", 16m, "A pesar de ser pareja, la vida cotidiana de Peter y Ann está marcada por la incomunicación y la soledad. Rehuyendo el intento de Ann por afrontar la situación, Peter decide pasar el día en el zoológicos de Central Park. Allí conocerá a Jerry, un excéntrico personaje que le obliga a escuchar sus historias hasta la última y más espeluznante de todas: el motivo real de su visita al zoo.", "Camino al Zoo" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "Capacidad", "Nombre" },
                values: new object[] { 1, 120, "gfgrqe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
