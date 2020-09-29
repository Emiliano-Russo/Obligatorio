using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ObligatorioDDA2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    email = table.Column<string>(nullable: false),
                    contrasenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Estadia",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Salida = table.Column<DateTime>(nullable: false),
                    RangoEdadInterno_no_usar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadia", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PuntosTuristicos",
                columns: table => new
                {
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Region = table.Column<int>(nullable: false),
                    CategoriasInterno_no_usar = table.Column<string>(nullable: true),
                    ImgNameInterno_no_usar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntosTuristicos", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Alojamiento",
                columns: table => new
                {
                    Nombre = table.Column<string>(nullable: false),
                    Estrellas = table.Column<float>(nullable: false),
                    PuntoTuristicoNombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    PrecioNoche = table.Column<float>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    SinCapacidad = table.Column<bool>(nullable: false),
                    NroTelefono = table.Column<string>(nullable: true),
                    InfoDeContacto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamiento", x => x.Nombre);
                    table.ForeignKey(
                        name: "FK_Alojamiento_PuntosTuristicos_PuntoTuristicoNombre",
                        column: x => x.PuntoTuristicoNombre,
                        principalTable: "PuntosTuristicos",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfoReserva",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EstadiaKey = table.Column<int>(nullable: true),
                    HotelNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoReserva", x => x.Key);
                    table.ForeignKey(
                        name: "FK_InfoReserva_Estadia_EstadiaKey",
                        column: x => x.EstadiaKey,
                        principalTable: "Estadia",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoReserva_Alojamiento_HotelNombre",
                        column: x => x.HotelNombre,
                        principalTable: "Alojamiento",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    InfoReservaKey = table.Column<int>(nullable: true),
                    EstadoReserva = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Reserva_InfoReserva_InfoReservaKey",
                        column: x => x.InfoReservaKey,
                        principalTable: "InfoReserva",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alojamiento_PuntoTuristicoNombre",
                table: "Alojamiento",
                column: "PuntoTuristicoNombre");

            migrationBuilder.CreateIndex(
                name: "IX_InfoReserva_EstadiaKey",
                table: "InfoReserva",
                column: "EstadiaKey");

            migrationBuilder.CreateIndex(
                name: "IX_InfoReserva_HotelNombre",
                table: "InfoReserva",
                column: "HotelNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_InfoReservaKey",
                table: "Reserva",
                column: "InfoReservaKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "InfoReserva");

            migrationBuilder.DropTable(
                name: "Estadia");

            migrationBuilder.DropTable(
                name: "Alojamiento");

            migrationBuilder.DropTable(
                name: "PuntosTuristicos");
        }
    }
}
