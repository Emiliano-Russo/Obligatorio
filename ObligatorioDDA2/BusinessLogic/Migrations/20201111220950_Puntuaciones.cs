using Microsoft.EntityFrameworkCore.Migrations;

namespace ObligatorioDDA2.Migrations
{
    public partial class Puntuaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puntuacion",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntos = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    ReservaCodigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puntuacion", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Puntuacion_Reserva_ReservaCodigo",
                        column: x => x.ReservaCodigo,
                        principalTable: "Reserva",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puntuacion_ReservaCodigo",
                table: "Puntuacion",
                column: "ReservaCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puntuacion");
        }
    }
}
