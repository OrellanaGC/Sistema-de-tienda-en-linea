using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class nombredir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "direccion",
                table: "Direccion",
                newName: "nombre_direccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre_direccion",
                table: "Direccion",
                newName: "direccion");
        }
    }
}
