using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrador.Migrations
{
    public partial class MigracionAdministradorRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministradorRol",
                columns: table => new
                {
                    IdAdministrador = table.Column<int>(nullable: false),
                    IdRol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradorRol", x => new { x.IdAdministrador, x.IdRol });
                    table.ForeignKey(
                        name: "FK_AdministradorRol_Administrador_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administrador",
                        principalColumn: "IdAdministrador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministradorRol_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorRol_IdRol",
                table: "AdministradorRol",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministradorRol");
        }
    }
}
