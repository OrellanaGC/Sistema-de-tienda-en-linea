using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class VendedorYTarjeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "detalleVendedorID",
                table: "Tarjeta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_detalleVendedorID",
                table: "Tarjeta",
                column: "detalleVendedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                table: "Tarjeta",
                column: "detalleVendedorID",
                principalTable: "DetalleVendedor",
                principalColumn: "DetalleVendedorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                table: "Tarjeta");

            migrationBuilder.DropIndex(
                name: "IX_Tarjeta_detalleVendedorID",
                table: "Tarjeta");

            migrationBuilder.DropColumn(
                name: "detalleVendedorID",
                table: "Tarjeta");
        }
    }
}
