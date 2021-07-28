using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrador.Migrations
{
    public partial class MigracionDispositivo : Migration
    {
        //Generar paquete de migracion atraves de clases establece como crear las tablas en 
        //funcion a lo que se definio en el modelo Dispositivo
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    IdDispositivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.IdDispositivo);
                });
        }

        //Metodo down, eliminar la tabla si es requerido
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositivo");
        }
    }
}
