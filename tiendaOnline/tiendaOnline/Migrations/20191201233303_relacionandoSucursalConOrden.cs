using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class relacionandoSucursalConOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sucursalID",
                table: "Orden",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orden_sucursalID",
                table: "Orden",
                column: "sucursalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Sucursal_sucursalID",
                table: "Orden",
                column: "sucursalID",
                principalTable: "Sucursal",
                principalColumn: "SucursalID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Sucursal_sucursalID",
                table: "Orden");

            migrationBuilder.DropIndex(
                name: "IX_Orden_sucursalID",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "sucursalID",
                table: "Orden");
        }
    }
}
