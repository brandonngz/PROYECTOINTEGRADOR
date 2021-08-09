using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrador.Migrations
{
    public partial class MigracionHistorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    IdHistorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    usuario = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.IdHistorial);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historial");
        }
    }
}
