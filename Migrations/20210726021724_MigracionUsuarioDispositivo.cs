using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrador.Migrations
{
    public partial class MigracionUsuarioDispositivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioDispositivo",//Nombre de la tabla
                columns: table => new
                {   //Campos que hemos definido
                    IdUsuario = table.Column<int>(nullable: false),
                    IdDispositivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {   //Primary Key  compuesta por los 2 campos que definimos, en en modelo UsuarioDispositivo
                    table.PrimaryKey("PK_UsuarioDispositivo", x => new { x.IdUsuario, x.IdDispositivo });
                    table.ForeignKey(
                        name: "FK_UsuarioDispositivo_Dispositivo_IdDispositivo",
                        column: x => x.IdDispositivo,
                        principalTable: "Dispositivo",
                        principalColumn: "IdDispositivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioDispositivo_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDispositivo_IdDispositivo",
                table: "UsuarioDispositivo",
                column: "IdDispositivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDispositivo");
        }
    }
}
