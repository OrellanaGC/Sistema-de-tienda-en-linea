using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class orden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "direccionID",
                table: "Orden",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tarjetaID",
                table: "Orden",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orden_direccionID",
                table: "Orden",
                column: "direccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_tarjetaID",
                table: "Orden",
                column: "tarjetaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Direccion_direccionID",
                table: "Orden",
                column: "direccionID",
                principalTable: "Direccion",
                principalColumn: "DireccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Tarjeta_tarjetaID",
                table: "Orden",
                column: "tarjetaID",
                principalTable: "Tarjeta",
                principalColumn: "TarjetaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Direccion_direccionID",
                table: "Orden");

            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Tarjeta_tarjetaID",
                table: "Orden");

            migrationBuilder.DropIndex(
                name: "IX_Orden_direccionID",
                table: "Orden");

            migrationBuilder.DropIndex(
                name: "IX_Orden_tarjetaID",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "direccionID",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "tarjetaID",
                table: "Orden");
        }
    }
}
